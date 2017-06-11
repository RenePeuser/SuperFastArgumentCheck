// Decompiled with JetBrains decompiler
// Type: Microsoft.VisualStudio.TestTools.UnitTesting.ExpectedArgumentException
// Assembly: Microsoft.VisualStudio.TestPlatform.TestFramework, Version=14.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: 1D684674-FFD1-4366-9207-E3F4167C11CB
// Assembly location: D:\GitHub\SuperFastArgumentCheck\SuperFastArgumentCheckTest\packages\MSTest.TestFramework.1.1.11\lib\net45\Microsoft.VisualStudio.TestPlatform.TestFramework.dll

using System;
using System.Globalization;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SuperFastArgumentCheckTest
{
    /// <summary>
    /// Attribute that specifies to expect an exception of the specified type
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class ExpectedArgumentException : ExpectedExceptionBaseAttribute
    {
        /// <summary>
        /// Gets the message to include in the test result if the test fails due to not throwing an exception
        /// </summary>
        protected override string NoExceptionMessage
        {
            get
            {
                return string.Format((IFormatProvider)CultureInfo.CurrentCulture, FrameworkMessages.UTF_TestMethodNoException, (object)this.ExceptionType.FullName, (object)this.SpecifiedNoExceptionMessage);
            }
        }

        /// <summary>
        /// Gets a value indicating the Type of the expected exception
        /// </summary>
        public Type ExceptionType { get; private set; }

        public string ParameterName { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether to allow types derived from the type of the expected exception to
        /// qualify as expected
        /// </summary>
        public bool AllowDerivedTypes { get; set; }

        /// <summary>Initializes the expected type</summary>
        /// <param name="exceptionType">Type of the expected exception</param>
        public ExpectedArgumentException(Type exceptionType, string parameterName)
            : this(exceptionType, parameterName, string.Empty)
        {
        }

        /// <summary>
        /// Initializes the expected type and the message to include when no exception is thrown by
        /// the test
        /// </summary>
        /// <param name="exceptionType">Type of the expected exception</param>
        /// <param name="noExceptionMessage">
        /// Message to include in the test result if the test fails due to not throwing an exception
        /// </param>
        public ExpectedArgumentException(Type exceptionType, string parameterName, string noExceptionMessage)
            : base(noExceptionMessage)
        {
            if (exceptionType == null)
                throw new ArgumentNullException(nameof(exceptionType));

            if (parameterName == null)
                throw new ArgumentNullException(nameof(parameterName));

            if (!typeof(ArgumentException).GetTypeInfo().IsAssignableFrom(exceptionType.GetTypeInfo()))
                throw new ArgumentException(FrameworkMessages.UTF_ExpectedExceptionTypeMustDeriveFromException, nameof(exceptionType));

            this.ExceptionType = exceptionType;
            this.ParameterName = parameterName;
        }

        /// <summary>
        /// Verifies that the type of the exception thrown by the unit test is expected
        /// </summary>
        /// <param name="exception">The exception thrown by the unit test</param>
        protected override void Verify(Exception exception)
        {
            var type = exception.GetType();
            var argumentException = (ArgumentException)exception;
            if (this.AllowDerivedTypes)
            {
                if (!this.ExceptionType.GetTypeInfo().IsAssignableFrom(type.GetTypeInfo()))
                {
                    this.RethrowIfAssertException(exception);
                    throw new Exception(string.Format(CultureInfo.CurrentCulture, FrameworkMessages.UTF_TestMethodWrongExceptionDerivedAllowed, (object)type.FullName, (object)this.ExceptionType.FullName, (object)UtfHelper.GetExceptionMsg(exception)));
                }
            }
            else if (type != this.ExceptionType)
            {
                this.RethrowIfAssertException(exception);
                throw new Exception(string.Format(CultureInfo.CurrentCulture, FrameworkMessages.UTF_TestMethodWrongException, type.FullName, this.ExceptionType.FullName, UtfHelper.GetExceptionMsg(exception)));
            }

            Assert.AreEqual(ParameterName, argumentException.ParamName, $"Expected parameter: '{ParameterName}' current parameter: '{argumentException.ParamName}'");
        }
    }
}
