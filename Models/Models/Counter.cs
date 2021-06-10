using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal static class Counter
    {
        internal static int counter = 0;
        internal static int GetCounter { get { return ++counter; } } 

    }
}
