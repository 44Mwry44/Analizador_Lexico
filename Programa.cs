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
        List<string> _lstCodigoFuente = new List<string>();
        Hashtable _Tokens = new Hashtable();
        ListaTokens _lstToken = new ListaTokens();
        DataTable _Gramaticas = new DataTable();

        public List<string> LstCodigoFuente 
        {
            get { return _lstCodigoFuente; }
        }

        public ListaTokens LstTokens
        {
            get { return _lstToken; }
        }

        public DataTable Gramaticas
        {
            get { return _Gramaticas; }
            set { _Gramaticas = value; }
        }

        //Almacena en una lista de cadenas, linea por linea del codigo fuente
        public void generarCodigoFuente(string miCodigoFuente)
        {
            string aux = "";

            //Recorre caracter por caracter
            foreach(char caracter in miCodigoFuente)
            {
                //Detecta un \n
                if(caracter == 13)
                {
                    //añade la cadeña(linea) a la lista y reinicia la cadena auxiliar
                    _lstCodigoFuente.Add(aux);
                    aux = "";
                }

                //Detecta el fin del texto
                if(caracter == 3)
                {
                    _lstCodigoFuente.Add(aux);
                    break;
                }

                //añade el caracter a la cadena de la linea
                aux = aux + caracter;
            }
        }

        public void obtenerTokens(string misTokens)
        {
            if(LstTokens.LstTokens.Count != 0)
            {
                Console.WriteLine("Limpie la lista de Tokens");
                LstTokens.LstTokens = new List<List<Token>>();
            }

            string auxString = "";
            Token auxToken;
            for(int x = 0; x < misTokens.Length; x++)
            {
                //Si encuentro un espacio, almaceno la linea, refresco el token auxiliar y doy un paso en el ciclo.
                if (misTokens[x] == 32)
                {
                    auxToken = new Token();
                    auxToken.StrToken = auxString;
                    _lstToken.LstLineaTokens.Add(auxToken);
                    auxString = "";
                    continue;
                }

                //Si encuentro un salto de linea, almaceno la linea, refresco el token auxiliar y doy un paso en el ciclo.
                if (misTokens[x] == 10)
                {
                    //Console.WriteLine("Encontre un salto de linea");
                    auxToken = new Token();
                    auxToken.StrToken = auxString;
                    _lstToken.LstLineaTokens.Add(auxToken);
                    _lstToken.LstTokens.Add(_lstToken.LstLineaTokens);
                    //Reinicio la linea
                    _lstToken.LstLineaTokens = new List<Token>();
                    auxString = "";
                    continue;
                }

                //Si llego al fin de la linea, almaceno la linea y salgo del ciclo.
                if(x == misTokens.Length-1)
                {
                    auxToken = new Token();
                    auxString += misTokens[x];
                    auxToken.StrToken = auxString;
                    _lstToken.LstLineaTokens.Add(auxToken);
                    _lstToken.LstTokens.Add(_lstToken.LstLineaTokens);
                    break;
                }

                //Ningun caso se dio, almaceno el caracter en el token auxiliar
                auxString += misTokens[x];
            }
        }

        //BottomUp - Stack Ver 1.0

        //IF ( ( a > b ) || ( c > a ) )
        //PR05 CE14 CE14 IDEN2 OPR2 IDEN4 CE15 OPLO CE14 IDEN6 OPR2 IDEN6 CE15 CE15
        //PR05 CE14 OPREL OPLO CE14 IDEN6 OPR2 IDEN6 CE15 CE15
        //PR05 CE14 OPREL OPLO OPREL CE15
        //PR05 CE14 OPLOG CE15
        //
        public void verificarSintaxis()
        {
            //Si Existen lineas derivadas, reinicia la lista
            if (LstTokens.LineasDerivadas.Count > 0)
            {
                //Console.WriteLine("Limpie las derivaciones");
                LstTokens.LineasDerivadas = new List<List<Token>>();
            }

            //Stack que almacenara cada nivel de analizis por linea
            Stack<List<Token>> BPStack = new Stack<List<Token>>();

            LstTokens.LstTokens.ForEach((linea) =>
            {
                //Linea auxiliar que se almacenara en el stack si es necesario
                List<Token> lineaAux = new List<Token>();
                List<Token> lineaDerivada = new List<Token>();

                foreach (Token token in linea)
                {
                    Console.Write(token.StrToken + ' ');
                }

                Console.Write('\n');

                foreach (Token token in linea)
                {
                    //Encuentro un '(', agrego el token a la lista y la agrego al stack
                    if (token.StrToken == "CE14")
                    {
                        lineaAux.Add(token);

                        //foreach (Token item in lineaAux)
                        //{
                        //    Console.Write(item.StrToken + ' ');
                        //}

                        //Console.Write('\n');

                        BPStack.Push(lineaAux);
                        lineaAux = new List<Token>();
                        continue;
                    }

                    //Encuentro un ')' - Derivo el contenido actual de mi linea, al finalizar, saco el contenido de la pila, y agrego los tokens obtenidos
                    if (token.StrToken == "CE15")
                    { 
                        lineaDerivada = Derivar(lineaAux, true);
                        
                        if(BPStack.Count > 0)
                        {
                            lineaAux = BPStack.Pop();
                        }

                        lineaDerivada.ForEach((item) => lineaAux.Add(item));

                        lineaAux.Add(token);

                        //foreach (Token item in lineaAux)
                        //{
                        //    Console.Write(item.StrToken + ' ');
                        //}

                        //Console.Write('\n');

                        continue;
                    }

                    lineaAux.Add(token);
                }

                //Console.Write("Ultima derivacion: ");
                //foreach(Token token in lineaAux)
                //{
                //    Console.Write(token.StrToken + ' ');
                //}

                //Console.Write("\n");

                lineaDerivada = Derivar(lineaAux, false);

                LstTokens.LineasDerivadas.Add(lineaDerivada);
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
