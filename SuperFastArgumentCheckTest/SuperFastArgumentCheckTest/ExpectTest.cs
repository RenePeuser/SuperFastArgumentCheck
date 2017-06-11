using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SuperFastArgumentCheckTest
{
    [TestClass]
    public class ExpectTest
    {
        [TestMethod]
        [ExpectedArgumentException(typeof(ArgumentNullException), "name")]
        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        public void If_Argument_Is_Null_Then_Argument_Null_Exception_Has_To_Be_Thrown()
        {
            var testClassExpected = new TestClassExpected(null);
        }
    }
}