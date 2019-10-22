using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apCaminhosMarte
{
    class PilhaCheiaException : Exception
    {
        public PilhaCheiaException(String err) : base(err)
        {

        }
    }
}
