using System;
using System.Linq.Expressions;

namespace SuperFastArgumentCheckTest
{
    public class TestClassExpressionCompile
    {
        public string Name { get; }

        public TestClassExpressionCompile(string name)
        {
            IsNull(() => name);
            Name = name;
        }

        private static void IsNull(Expression<Func<object>> argumentExpression)
        {
            var compiledExpression = argumentExpression.Compile();
            var argumentValue = compiledExpression();
            if (argumentValue == null)
            {
                var memberExpression = (MemberExpression)argumentExpression.Body;
                throw new ArgumentNullException(memberExpression.Member.Name);
            }
        }
    }
}