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
    }
}
