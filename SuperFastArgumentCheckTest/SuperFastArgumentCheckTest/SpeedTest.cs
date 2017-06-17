using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SuperFastArgumentCheckTest
{
    [TestClass]
    public class SpeedTest
    {
        private const int counter = 100000;

        [TestMethod]
        public void InterateStandard()
        {
            for (int i = 0; i < counter; i++)
            {
                var result = new TestClassStandard(i.ToString());
            }
        }

        [TestMethod]
        public void InterateExpect()
        {
            for (int i = 0; i < counter; i++)
            {
                var result = new TestClassExpectedOnlyOneArgument(i.ToString());
            }
        }

        [TestMethod]
        public void InterateExtended()
        {
            for (int i = 0; i < counter; i++)
            {
                var result = new TestClassOnlyOneArgument(i.ToString());
            }
        }

        [TestMethod]
        public void InterateExpressionCompile()
        {
            for (int i = 0; i < counter; i++)
            {
                var result = new TestClassExpressionCompile(i.ToString());
            }
        }

        [TestMethod]
        public void InterateExpressionWithoutCompile()
        {
            for (int i = 0; i < counter; i++)
            {
                var result = new TestClassExpressionWithout(i.ToString());
            }
        }

        [TestMethod]
        public void InterateWithAnonymType()
        {
            for (int i = 0; i < counter; i++)
            {
                var result = new TestClassAnonym(i.ToString());
            }
        }

        //[TestMethod]
        //public void IterateWithFunc()
        //{
        //    for (int i = 0; i < counter; i++)
        //    {
        //        var result = new TestClassFunc(i.ToString());
        //    }
        //}

        [TestMethod]
        public void IterateWithFuncAndReturn()
        {
            for (int i = 0; i < counter; i++)
            {
                var result = new TestClassFuncAndReturn(i.ToString());
            }
        }
    }
}