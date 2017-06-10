using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperFastArgumentCheck;

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

    public static class ExceptionHelper
    {
        public static T Throws<T>(Func<object> creation, string argumentName) where T : ArgumentException
        {
            T exception = null;
            try
            {
                var result = creation();
            }
            catch (Exception e)
            {
                Assert.AreEqual(typeof(T), e.GetType());
                exception = e as T;
                Assert.AreEqual(argumentName, exception.ParamName);
            }

            return exception;
        }
    }
}