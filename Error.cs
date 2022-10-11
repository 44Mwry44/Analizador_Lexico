using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_Lexico
{
    public class Error
    {
        private int intNumero;

        public int Numero
        {
            get { return intNumero; }
            set { intNumero = value; }
        }

        private string strTipo;

        public  string Tipo_de_Error
        {
            get { return strTipo; }
            set { strTipo = value; }
        }

        private int intLineaError;

        public int Linea_Error
        {
            get { return intLineaError; }
            set { intLineaError = value; }
        }

    }
}
