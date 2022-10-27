using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Analizador_Lexico
{
    class ListaTokens
    {
        List<Token> _lstLineaTokens = new List<Token>();
        List<List<Token>> _lstTokens = new List<List<Token>>();
        List<List<Token>> _lstLineasDerivadas = new List<List<Token>>();

        List<List<Token>> _lstProcesoDeDerivacion = new List<List<Token>>();

        public List<Token> LstLineaTokens
        {
            get { return _lstLineaTokens; }
            set { _lstLineaTokens = value; }
        }

        public List<List<Token>> LstTokens
        {
            get { return _lstTokens; }
            set { _lstTokens = value; }
        }

        public List<List<Token>> LineasDerivadas
        {
            get { return _lstLineasDerivadas; }
            set { _lstLineasDerivadas = value; }
        }

        public List<List<Token>> LstProcesoDeDerivacion
        {
            get { return _lstProcesoDeDerivacion; }
            set { _lstProcesoDeDerivacion = value; }
        }

        public void AddLineaDeTokens(List<Token> miLstTokens)
        {
            _lstTokens.Add(miLstTokens);
        }

        public void DepurarTokens()
        {
            List<Token> auxLinea = new List<Token>();
            List<List<Token>> auxPrograma = new List<List<Token>>();
            
            LstTokens.ForEach((linea) => {
                linea.ForEach((token) => {
                    if(token.StrToken.Length > 4)
                    {
                        Token auxToken = new Token();
                        auxToken.StrToken = token.StrToken.Remove(4);
                        //Console.WriteLine(auxToken.StrToken);
                        auxLinea.Add(auxToken);
                    }
                    else
                    {
                        auxLinea.Add(token);
                    }
                });
                auxPrograma.Add(auxLinea);
                auxLinea = new List<Token>();
            });

            LstTokens = auxPrograma;

            //LstTokens.ForEach((linea) => {
            //    linea.ForEach((token) => {
            //        Console.Write(token.StrToken + ' ');
            //    });
            //    Console.Write('\n');
            //});
        }

        public static List<int> ObtenerPosiciones(List<Token> seccionDerivada, List<Token> linea)
        {
            List<int> posiciones = new List<int>();
            int indexSeccion = 0;

            for(int indexLinea = 0; indexLinea < linea.Count; indexLinea++)
            {
                while (linea.ElementAt(indexLinea).equals(seccionDerivada.ElementAt(indexSeccion)))
                {
                    posiciones.Add(indexLinea);
                    indexLinea++;

                    if(indexSeccion == seccionDerivada.Count - 1)
                    {
                        break;
                    }

                    indexSeccion++;
                }

                if (indexSeccion == seccionDerivada.Count - 1)
                {
                    break;
                }

                if (indexSeccion != 0)
                {
                    posiciones = new List<int>();
                }
                indexSeccion = 0;
                //indexLinea++;
            }

            return posiciones;
        }

        public static List<Token> ReducirLinea(List<int> posiciones, List<Token> linea, Token tokenObtenido)
        {
            List<Token> aux = new List<Token>();
            bool saltarToken = false, tokenDerivadoAgregado = false;
            int posicion = 0;

            foreach(Token token in linea)
            {
                saltarToken = false;
                while(posicion < posiciones.Count - 1)
                {
                    if (linea.FindIndex(item => item.equals(token)) == posicion)
                    {
                        saltarToken = true;
                        posicion++;
                        break;
                    }
                }

                if(posicion == posiciones.Count - 1 && !tokenDerivadoAgregado)
                {
                    aux.Add(tokenObtenido);
                    tokenDerivadoAgregado = true;
                }

                if(saltarToken)
                {
                    continue;
                }

                aux.Add(token);
            }

            //foreach(Token miToken in aux)
            //{
            //    Console.WriteLine("Reduccion: \n");
            //    Console.Write(miToken.StrToken + ' ');
            //}

            //Console.Write('\n');

            return aux;
        }
    }
}
