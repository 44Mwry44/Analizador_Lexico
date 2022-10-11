using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_Lexico
{
    class Token
    {
        string _strToken = "";

        public string StrToken
        {
            get { return _strToken; }
            set { _strToken = value; }
        }
    }
}
