using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Exceptions
{
    public class GameEndException : ApplicationException
    {
        public GameEndException(string msg)
            : base(msg)
        {
        }

        public GameEndException(string msg, Exception innerEx)
            : base(msg, innerEx)
        {
        }
    }
}
