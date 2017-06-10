using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperFastArgumentCheck;

namespace SuperFastArgumentCheckApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DoSomething(null);
        }

        private static void DoSomething(string name)
        {
            Expect.NotNull(name);
        }
    }
}