using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snapmd.Core.Entities
{
    public class TransfusionsResult
    {
        public bool IsPossible { get; set; }
        public List<Transfusion> TransfusionsFirstWay { get; set; }
        public List<Transfusion> TransfusionsSecondWay { get; set; }
    }
}
