using System;
using System.Globalization;
using System.Text;
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
                    str = string.Format(CultureInfo.CurrentCulture, FrameworkMessages.UTF_FailedToGetExceptionMessage, exception.GetType());
                }
                stringBuilder.Append(string.Format(CultureInfo.CurrentCulture, "{0}{1}: {2}", flag ? string.Empty : " ---> ", exception.GetType(), str));
                flag = false;
            }
            return stringBuilder.ToString();
        }
    }
}
