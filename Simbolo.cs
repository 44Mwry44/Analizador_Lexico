using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_Lexico
{
    class Simbolo
    {
        private int intIdentificador;

        public int INDENTIFICADOR
        {
            get { return intIdentificador; }
            set { intIdentificador = value; }
        }

        private string strNombre;

        public  string NOMBRE
        {
            get { return strNombre; }
            set { strNombre = value; }
        }
        private double? dblValor;

        public double? VALOR
        {
            get { return dblValor; }
            set { dblValor = value; }
        }

        private string strDato;
        public string TIPODATO
        {
            get { return strDato; }
            set { strDato = value; }
        }

    }
}
