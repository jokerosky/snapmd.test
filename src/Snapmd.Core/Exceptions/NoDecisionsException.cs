using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snapmd.Core.Exceptions
{
    public class NoDecisionsException :Exception
    {
        public NoDecisionsException(string message):base(message){}
    }
}
