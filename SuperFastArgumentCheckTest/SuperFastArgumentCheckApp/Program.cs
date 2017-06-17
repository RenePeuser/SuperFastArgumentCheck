using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SuperFastArgumentCheck;

namespace SuperFastArgumentCheckApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DoSomething(null, "b", null, "u");
            DoSomething("c", "r", "f", string.Empty);
        }

        private static void DoSomething(string name, string dateTime, string next, string emptyValue)
        {
            Expect.NotNull(() => name);
            Expect.NotNull(() => dateTime);
            Expect.NotNull(() => next);
            Expect.IsEmpty(() => emptyValue);

        }
    }
}