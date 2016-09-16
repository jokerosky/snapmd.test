using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snapmd.Core.Entities
{
    public class Jar
    {
        public string Id { get; set; }
        public int Capacity { get; set; }
        public string Color { get; set; }

        public Jar(int capacity)
        {
            Capacity = capacity;
        }
    }
}
