using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperFastArgumentCheck;

namespace SuperFastArgumentCheckTest
{
    [TestClass]
    public class ExpectTest
    {
        [TestMethod]
        [MethodImpl(MethodImplOptions.NoOptimization)]
        [ExpectedArgumentException(typeof(ArgumentNullException), "name")]
        public void If_Argument_Is_Null_Then_Argument_Null_Exception_Has_To_Be_Thrown()
        {
            new TestClassExpectedOnlyOneArgument(null);
        }
    }

    [TestClass]
    public class ArgumentCheck
    {
        [TestMethod]
        public void If_Arg_0_Is_Null_Then_Argument_Null_Exception_Has_To_Be_Thrown()
        {
            ExceptionHelper.Throws<ArgumentNullException>(() => new TestClassFunc(null, "b", "c", "d"), "arg0");
        }

        [TestMethod]
        public void If_Arg_1_Is_Null_Then_Argument_Null_Exception_Has_To_Be_Thrown()
        {
            ExceptionHelper.Throws<ArgumentNullException>(() => new TestClassFunc("a", null, "c", "d"), "arg1");
        }

        [TestMethod]
        public void If_Arg_2_Is_Null_Then_Argument_Null_Exception_Has_To_Be_Thrown()
        {
            ExceptionHelper.Throws<ArgumentNullException>(() => new TestClassFunc("a", "b", null, "d"), "arg2");
        }

        [TestMethod]
        public void If_Arg_3_Is_Null_Then_Argument_Null_Exception_Has_To_Be_Thrown()
        {
            ExceptionHelper.Throws<ArgumentNullException>(() => new TestClassFunc("b", "a", "c", null), "arg3");
        }
    }

    [TestClass]
    public class ArgumentTestClassTest
    {
        [TestMethod]
        public void If_Arg_0_Is_Null_Then_Argument_Null_Exception_Has_To_Be_Thrown()
        {
            ExceptionHelper.Throws<ArgumentNullException>(() => new ArgumentTestClass(null, "b", "c", 1), "cloneable");
        }

        [TestMethod]
        public void If_Arg_1_Is_Null_Then_Argument_Null_Exception_Has_To_Be_Thrown()
        {
            ExceptionHelper.Throws<ArgumentNullException>(() => new ArgumentTestClass(new object(), null, "c", 2), "name");
        }

        [TestMethod]
        public void If_Arg_1_Is_Empty_Then_Argument_Null_Exception_Has_To_Be_Thrown()
        {
            ExceptionHelper.Throws<ArgumentException>(() => new ArgumentTestClass(new object(), string.Empty, "c", 2), "name");
        }

        [TestMethod]
        public void If_Arg_1_Is_Whitespace_Then_Argument_Null_Exception_Has_To_Be_Thrown()
        {
            ExceptionHelper.Throws<ArgumentException>(() => new ArgumentTestClass(new object(), string.Empty, " ", 2), "name");
        }

        [TestMethod]
        public void If_Arg_2_Is_Null_Then_Argument_Null_Exception_Has_To_Be_Thrown()
        {
            ExceptionHelper.Throws<ArgumentNullException>(() => new ArgumentTestClass(new object(), "b", null, 3), "something");
        }

        [TestMethod]
        public void If_Arg_2_Is_Empty_Then_Argument_Null_Exception_Has_To_Be_Thrown()
        {
            ExceptionHelper.Throws<ArgumentException>(() => new ArgumentTestClass(new object(), "b", string.Empty, 3), "something");
        }

        [TestMethod]
        public void If_Arg_2_Is_Whitespace_Then_Argument_Null_Exception_Has_To_Be_Thrown()
        {
            ExceptionHelper.Throws<ArgumentException>(() => new ArgumentTestClass(new object(), "b", " ", 3), "something");
        }

        [TestMethod]
        public void If_Arg_3_Is_Out_Of_Range_Then_Argument_Null_Exception_Has_To_Be_Thrown()
        {
            ExceptionHelper.Throws<ArgumentException>(() => new ArgumentTestClass(new object(), "b", "g", 3), "age");
        }
    }
}