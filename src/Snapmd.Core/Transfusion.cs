using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snapmd.Core
{
    public class Transfusion
    {
        public int FirstJar;
        public int SecondJar;

        public Transfusion(int first, int second)
        {
            FirstJar = first;
            SecondJar = second;
        }

    }
}
