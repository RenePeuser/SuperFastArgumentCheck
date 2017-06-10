using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SuperFastArgumentCheckTest
{
    [TestClass]
    public class ExpectTest
    {
        [TestMethod]
        public void If_Argument_Is_Null_Then_Argument_Null_Exception_Has_To_Be_Thrown()
        {
            ExceptionHelper.Throws<ArgumentNullException>(() => new TestClassExpected(null), "name");
        }
    }
}