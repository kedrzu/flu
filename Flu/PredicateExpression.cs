using System;
using System.Linq.Expressions;

namespace Flu
{
    public partial class PredicateExpression<T> : IPredicateExpression<T>
    {
        public Expression<Func<T, bool>> Expression { get; set; }

        public Func<T, bool> Function { get; set; }

        LambdaExpression IPredicateExpression<T>.Expression => Expression;

        public PredicateExpression()
        {
        }

        public PredicateExpression(Expression<Func<T, bool>> expr, Func<T, bool> func = null)
        {
            Expression = expr;
            Function = func;
        }
    }
}
