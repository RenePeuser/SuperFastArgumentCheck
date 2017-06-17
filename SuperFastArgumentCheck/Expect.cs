using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SuperFastArgumentCheck
{
    public static class Expect
    {
        //[DebuggerHidden]
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public static T NotNullOneParam<T>(this T item, [CallerMemberName] string caller = "")
        {
            if (item == null)
            {
                StackTrace stackTrace = new StackTrace();
                StackFrame frame = stackTrace.GetFrame(1);

                var parameter = frame.GetMethod().GetParameters().FirstOrDefault();
                if (parameter == null)
                {
                    throw new ArgumentException("Check code optimization settings, no parameter info is existing.");
                }
                throw new ArgumentNullException(parameter.Name);
            }
            return item;
        }

        //[DebuggerHidden]
        public static void NotNullAnonym<T>(this T item)
        {
            var propertyInfo = typeof(T).GetProperties()[0];
            var value = propertyInfo.GetValue(item);
            if (value == null)
            {
                throw new ArgumentNullException(propertyInfo.Name);
            }
        }

        //[DebuggerHidden]
        public static T NotNull<T>(Func<T> func)
        {
            var value = func();
            if (value == null)
            {
                var fields = func.Target.GetType().GetFields();
                var fieldInfo = fields.FirstOrDefault(f => f.GetValue(func.Target) == null);
                throw new ArgumentNullException(fieldInfo.Name);
            }
            return value;
        }

        //[DebuggerHidden]
        public static string IsEmpty(Func<string> func)
        {
            var value = func();
            if (string.IsNullOrEmpty(value))
            {
                var fields = func.Target.GetType().GetFields();
                var fieldInfo = fields.FirstOrDefault(f => f.GetValue(func.Target) is string && string.IsNullOrEmpty((string)f.GetValue(func.Target)));
                throw new ArgumentException("The string must not be null or empyty", fieldInfo.Name);
            }
            return value;
        }

        //[DebuggerHidden]
        public static string IsWhitespace(Func<string> func)
        {
            var value = func();
            if (string.IsNullOrWhiteSpace(value))
            {
                var fields = func.Target.GetType().GetFields();
                var fieldInfo = fields.FirstOrDefault(f => f.GetValue(func.Target) is string && string.IsNullOrWhiteSpace((string)f.GetValue(func.Target)));
                throw new ArgumentException("The string must not be null or whitespace", fieldInfo.Name);
            }
            return value;
        }

        //[DebuggerHidden]
        public static int IsLowerThan(Func<int> func, int limit)
        {
            var value = func();
            if (value < limit)
            {
                var fields = func.Target.GetType().GetFields();
                var fieldInfo = fields.FirstOrDefault(f => (int)f.GetValue(func.Target) < limit);
                throw new ArgumentException("The value must not be lower than: ....", fieldInfo.Name);
            }
            return value;
        }

        //[DebuggerHidden]
        public static int IsGreaterThan(Func<int> func, int limit)
        {
            var value = func();
            if (value > limit)
            {
                var fields = func.Target.GetType().GetFields();
                var fieldInfo = fields.FirstOrDefault(f => (int)f.GetValue(func.Target) > limit);
                throw new ArgumentException("The value must not be greater than: ....", fieldInfo.Name);
            }
            return value;
        }

        //[DebuggerHidden]
        public static int IsOutOfRange(Func<int> func, int min, int max)
        {
            var value = func();
            if (value < min && value > max)
            {
                var fields = func.Target.GetType().GetFields();
                var fieldInfo = fields.FirstOrDefault(f => (int)f.GetValue(func.Target) < min && (int)f.GetValue(func.Target) > max);
                throw new ArgumentException("The value must be in range from .. till ..", fieldInfo.Name);
            }
            return value;
        }
    }
}
