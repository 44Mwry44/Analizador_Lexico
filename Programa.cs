using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Analizador_Lexico
{
    class Programa
    {
        string _strCodigoFuente = "";
        ListaTokens _tokens = new ListaTokens();
        DataTable _Matriz = new DataTable();
        DataTable _Gramaticas = new DataTable();
        bool _matrizNormalizada = false;

        public string StrCodigoFuente 
        {
            get { return _strCodigoFuente; }
            set { _strCodigoFuente = value; }
        }

        public ListaTokens Tokens
        {
            get { return _tokens; }
            set { _tokens = value; }
        }

        public DataTable Gramaticas
        {
            get { return _Gramaticas; }
            set { _Gramaticas = value; }
        }

        public DataTable Matriz
        {
            get { return _Matriz; }
            set { _Matriz = value; }
        }

        //Almacena en una lista de cadenas, linea por linea del codigo fuente
        //public void generarCodigoFuente(string miCodigoFuente)
        //{
        //    string aux = "";

        //    //Recorre caracter por caracter
        //    foreach(char caracter in miCodigoFuente)
        //    {
        //        //Detecta un \n
        //        if(caracter == 13)
        //        {
        //            //añade la cadeña(linea) a la lista y reinicia la cadena auxiliar
        //            _lstCodigoFuente.Add(aux);
        //            aux = "";
        //        }

        //        //Detecta el fin del texto
        //        if(caracter == 3)
        //        {
        //            _lstCodigoFuente.Add(aux);
        //            break;
        //        }

        //        //añade el caracter a la cadena de la linea
        //        aux = aux + caracter;
        //    }
        //}

        public void NormalizarMatriz()
        {
            for(int col = 0; col < Matriz.Columns.Count; col++)
            {
                //aux = Contenido de la celda
                string aux = Matriz.Rows[0][col].ToString();
                char caracterNormalizado = ' ';
                
                //Si la cadena es mayor a 1 y su primer caracter esta entre A-Z
                if(aux.Length > 1 && (aux[0] >= 65 && aux[0] <= 90))
                {
                    caracterNormalizado = aux[0];

                    //La celda ahora es el caracter unicamente
                    Matriz.Rows[0][col] = caracterNormalizado;
                }
            }

            _matrizNormalizada = true;
        }

        public void ObtenerTokens()
        {
            int estado, caracter, siguienteEstado = 0;

            foreach(List<Token> linea in Tokens.LstTokens)
            {
                foreach(Token token in linea)
                {
                    for(int x = 0; x< token.StrCodigo.Length; x++)
                    {
                        //Recorro la primer columna para buscar el caracter
                        for(caracter = 0; caracter < Matriz.Columns.Count; caracter++)
                        {
                            //Si encuentro un caracter permitido - obtengo su posicion(columna)
                            if(token.StrCodigo[x].ToString() == Matriz.Rows[0][caracter].ToString())
                            {
                                break;
                            }
                        }

                        for(estado = siguienteEstado; estado < Matriz.Rows.Count; estado++)
                        {
                            if(siguienteEstado == int.Parse(Matriz.Rows[estado][caracter].ToString()))
                            {
                                siguienteEstado = int.Parse(Matriz.Rows[estado][caracter].ToString());
                            }
                            break;
                        }
                    }

                    estado = siguienteEstado;

                    estado = int.Parse(Matriz.Rows[estado][90].ToString());

                    token.StrToken = Matriz.Rows[estado][91].ToString();
                }
            }

            Tokens.LstTokens.ForEach((linea) => {
                linea.ForEach((token) => {
                    Console.WriteLine("Linea: {0} Mi token es: {1}", token.NumLinea, token.StrToken);
                });
            });
        }

        public void GenerarTokens()
        {
            //if(!_matrizNormalizada)
            //{
            //    NormalizarMatriz();
            //}

            int numLinea = 1;
            Token auxToken = new Token();
            List<Token> linea = new List<Token>();

            for (int caracter = 0; caracter < StrCodigoFuente.Length; caracter++)
            {
                //Si encuentro un salto de linea o fin del codigo
                if (StrCodigoFuente[caracter] == 13 || StrCodigoFuente[caracter] == 3 || caracter == StrCodigoFuente.Length - 1)
                {
                    numLinea++;
                    this.Tokens.AddLineaDeTokens(linea);

                    //foreach (Token miToken in linea)
                    //{
                    //    Console.WriteLine("Mi codigo de mi token: " + miToken.StrCodigo);
                    //}

                    continue;
                }

                //Si encuentro un espacio
                if (StrCodigoFuente[caracter] == 32)
                {
                    linea.Add(auxToken);
                    auxToken = new Token();
                }

                //agrego el caracter al codigo del token
                auxToken.StrCodigo += StrCodigoFuente[caracter];
                auxToken.NumLinea = numLinea;
                Console.WriteLine("Encontre el caracter: " + StrCodigoFuente[caracter]);
            }
        }
        
        //BottomUp - Stack Ver 1.1

        //IF ( ( a > b ) || ( c > a ) )
        //PR05 CE14 CE14 IDEN2 OPR2 IDEN4 CE15 OPLO CE14 IDEN6 OPR2 IDEN6 CE15 CE15
        //PR05 CE14 OPREL OPLO CE14 IDEN6 OPR2 IDEN6 CE15 CE15
        //PR05 CE14 OPREL OPLO OPREL CE15
        //PR05 CE14 OPLOG CE15
        //INS_IF

        //PR05 CE14 INS_REL CE15 OPLOG CE15 INS_REL CE15
        //CE14 IDEN OPR2 IDEN CE15 - CE14 INS_REL CE15
        public void VerificarSintaxis()
        {
            //Si Existen lineas derivadas, reinicia la lista
            if (Tokens.LineasDerivadas.Count > 0)
            {
                //Console.WriteLine("Limpie las derivaciones");
                Tokens.LineasDerivadas = new List<List<Token>>();
            }

            //Stack que almacenara cada nivel de analizis por linea
            Stack<List<Token>> BPStack = new Stack<List<Token>>();

            Tokens.LstTokens.ForEach((linea) =>
            {
                //Linea auxiliar que se almacenara en el stack si es necesario
                List<Token> lineaAux = new List<Token>();
                List<Token> lineaDerivada = new List<Token>();

                //Imprime la linea sin derivar
                foreach (Token token in linea)
                {
                    Console.Write(token.StrToken + ' ');
                }

                Console.Write('\n');

                foreach (Token token in linea)
                {
                    //Stack = { [IF, (] }
                    //lineaAux = { ( }
                    //lineaDerivada = 
                    //aux = {  }
                    //Encuentro un '(', agrego el token a la lista y la agrego al stack
                    if (token.StrToken == "CE14")
                    {
                        lineaAux.Add(token);

                        BPStack.Push(lineaAux);

                        lineaAux = new List<Token>();
                        continue;
                    }

                    //Encuentro un ')' - Derivo el contenido actual de mi linea, al finalizar, saco el contenido de la pila, y agrego los tokens obtenidos
                    if (token.StrToken == "CE15")
                    {
                        lineaDerivada = Derivar(lineaAux, true);

                        lineaAux = BPStack.Pop();


                        lineaDerivada.ForEach((item) => lineaAux.Add(item));

                        lineaAux.Add(token);

                        continue;
                    }

                    lineaAux.Add(token);
                }

                if(BPStack.Count > 0)
                {
                    List<Token> aux = new List<Token>();

                    aux = lineaAux;

                    lineaAux = BPStack.Pop();

                    aux.ForEach((item) => lineaAux.Add(item));

                    lineaDerivada = Derivar(lineaAux, false);
                }
                else
                {
                    lineaDerivada = Derivar(lineaAux, false);
                }

                Tokens.LineasDerivadas.Add(lineaDerivada);
            });
        }

        public List<Token> Derivar(List<Token> linea, bool ignorarParentesis)
        {
            //Fila = 0; Estado 0
            int tokenActual = 0,  estadoActual = 2;
            Token lineaDerivada = new Token();

            //Por cada Token, recorrere la matriz
            foreach(Token token in linea)
            {
                //Si encuentro '(' o ')' damos un continue
                if ((token.StrToken == "CE14" || token.StrToken == "CE15") && ignorarParentesis)
                {
                    continue;
                }

                //Recorro las gramaticas
                for (int fila = tokenActual; fila < Gramaticas.Rows.Count; fila++)
                {
                    if (token.StrToken == Gramaticas.Rows[fila][estadoActual].ToString())
                    {
                        tokenActual = fila;
                        //Console.WriteLine("Encontre el token: " + Gramaticas.Rows[fila][estadoActual].ToString());

                        if (Gramaticas.Rows[fila][1].ToString() != "")
                        {
                            lineaDerivada.StrToken = Gramaticas.Rows[fila][1].ToString();
                            break;
                        }

                        estadoActual++;
                        break;
                    }
                }
                tokenActual++;
            }

            if(lineaDerivada != null)
            {
                //Reinicio la linea y la vuelvo el resultado de la derivacion
                linea = new List<Token>();
                linea.Add(lineaDerivada);
            }
            else
            {
                throw new Exception("Hay un error en la derivacion");
            }

            return linea;
        }
    }
}
