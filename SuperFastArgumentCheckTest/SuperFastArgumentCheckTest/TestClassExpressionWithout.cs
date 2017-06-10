using System;
using System.Configuration;
using System.Linq.Expressions;

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
            var memberExpression = (MemberExpression)argumentExpression.Body;
            

            var compiledExpression = argumentExpression.Compile();
            var argumentValue = compiledExpression();
            if (argumentValue == null)
            {
                throw new ArgumentNullException(memberExpression.Member.Name);
            }
        }
    }
}