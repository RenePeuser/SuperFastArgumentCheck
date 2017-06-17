using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SuperFastArgumentCheckTest
{
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