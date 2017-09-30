using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Flu
{
    public partial class PredicateExpression<T>
    {
        public static implicit operator PredicateExpression<T>(Expression<Func<T, bool>> expr)
        {
            return new PredicateExpression<T>(expr);
        }

        public static implicit operator Expression<Func<T, bool>>(PredicateExpression<T> predicate)
        {
            return predicate.Expression;
        }

        public static implicit operator Func<T, bool>(PredicateExpression<T> predicate)
        {
            var function = predicate.Function;
            if (function == null)
                return predicate.Expression.Compile();

            return predicate.Function;
        }

        public static PredicateExpression<T> operator &(PredicateExpression<T> x, IPredicateExpression<T> y)
        {
            return x.And(y);
        }

        public static PredicateExpression<T> operator &(IPredicateExpression<T> x, PredicateExpression<T> y)
        {
            return y.And(x);
        }

        public static PredicateExpression<T> operator &(PredicateExpression<T> x, PredicateExpression<T> y)
        {
            return y.And(x);
        }

        public static PredicateExpression<T> operator &(PredicateExpression<T> x, Expression<Func<T, bool>> y)
        {
            return x.And(y);
        }

        public static PredicateExpression<T> operator &(Expression<Func<T, bool>> x, PredicateExpression<T> y)
        {
            return y.And(x);
        }

        public static PredicateExpression<T> operator |(PredicateExpression<T> x, IPredicateExpression<T> y)
        {
            return x.Or(y);
        }

        public static PredicateExpression<T> operator |(IPredicateExpression<T> x, PredicateExpression<T> y)
        {
            return x.Or(y);
        }

        public static PredicateExpression<T> operator |(PredicateExpression<T> x, PredicateExpression<T> y)
        {
            return x.Or(y);
        }

        public static PredicateExpression<T> operator |(PredicateExpression<T> x, Expression<Func<T, bool>> y)
        {
            return x.Or(y);
        }

        public static PredicateExpression<T> operator |(Expression<Func<T, bool>> x, PredicateExpression<T> y)
        {
            return y.Or(x);
        }

        public static PredicateExpression<T> operator !(PredicateExpression<T> x)
        {
            return x.Not();
        }
    }
}
