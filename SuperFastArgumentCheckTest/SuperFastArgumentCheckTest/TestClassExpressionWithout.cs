using System;
using System.Configuration;
using System.Linq.Expressions;
using System.Reflection;

namespace SuperFastArgumentCheckTest
{
    public class TestClassExpressionWithout
    {
        public string Name { get; }

        public TestClassExpressionWithout(string name)
        {
            IsNull(() => name);

            Name = name;
        }

        private static void IsNull(Expression<Func<object>> argumentExpression)
        {
            var memberSelector = (MemberExpression)argumentExpression.Body;
            var constantSelector = (ConstantExpression)memberSelector.Expression;
            object value = ((FieldInfo)memberSelector.Member)
                .GetValue(constantSelector.Value);

            if (value == null)
            {
                string name = ((MemberExpression)argumentExpression.Body).Member.Name;
                throw new ArgumentNullException(name);
            }

        }
    }
}