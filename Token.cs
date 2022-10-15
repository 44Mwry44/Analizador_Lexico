using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_Lexico
{
    class Token
    {
        string _strCodigo = "";
        string _strToken = "";
        int _intLinea = 0;

        public string StrToken
        {
            get { return _strToken; }
            set { _strToken = value; }
        }

        public int NumLinea
        {
            get { return _intLinea; }
            set { _intLinea = value; }
        }

        public string StrCodigo
        {
            get { return _strCodigo; }
            set { _strCodigo = value; }
        }
    }
}
