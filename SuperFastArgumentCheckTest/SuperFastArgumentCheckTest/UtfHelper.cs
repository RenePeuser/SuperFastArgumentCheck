using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SuperFastArgumentCheckTest
{
    internal static class UtfHelper
    {
        /// <summary>
        /// Gets the exception messages, including the messages for all inner exceptions
        /// recursively
        /// </summary>
        /// <param name="ex">Exception to get messages for</param>
        /// <returns>string with error message information</returns>
        internal static string GetExceptionMsg(Exception ex)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool flag = true;
            for (Exception exception = ex; exception != null; exception = exception.InnerException)
            {
                string str;
                try
                {
                    str = exception.Message;
                }
                catch
                {
                    str = string.Format((IFormatProvider)CultureInfo.CurrentCulture, FrameworkMessages.UTF_FailedToGetExceptionMessage, (object)exception.GetType());
                }
                stringBuilder.Append(string.Format((IFormatProvider)CultureInfo.CurrentCulture, "{0}{1}: {2}", (object)(flag ? string.Empty : " ---> "), (object)exception.GetType(), (object)str));
                flag = false;
            }
            return stringBuilder.ToString();
        }
    }
}
