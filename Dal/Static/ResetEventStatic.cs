using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Static
{
    public static class ResetEventStatic
    {
        public static AutoResetEvent AddResetEvent = new AutoResetEvent(false);
    }
}
