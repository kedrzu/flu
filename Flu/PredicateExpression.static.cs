using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Flu
{
    public static class PredicateExpression
    {
        public static PredicateExpression<T> True<T>() { return new PredicateExpression<T>(f => true); }

        public static PredicateExpression<T> False<T>() { return new PredicateExpression<T>(f => false); }

        public static PredicateExpression<T> Or<T>(this IPredicateExpression<T> predicate1, PredicateExpression<T> predicate2)
        {
            return predicate1.Or((IPredicateExpression<T>)predicate2);
        }

        public static PredicateExpression<T> Or<T>(this IPredicateExpression<T> predicate1, IPredicateExpression<T> predicate2)
        {
            var invokedExpr = Expression.Invoke(predicate2.Expression, predicate1.Expression.Parameters);
            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(predicate1.Expression.Body, invokedExpr), predicate1.Expression.Parameters);
        }

        public static PredicateExpression<T> And<T>(this IPredicateExpression<T> predicate1, PredicateExpression<T> predicate2)
        {
            return predicate1.And((IPredicateExpression<T>)predicate2);
        }

        public static PredicateExpression<T> And<T>(this IPredicateExpression<T> predicate1, IPredicateExpression<T> predicate2)
        {
            var invokedExpr = Expression.Invoke(predicate2.Expression, predicate1.Expression.Parameters);
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(predicate1.Expression.Body, invokedExpr), predicate1.Expression.Parameters);
        }

        public static PredicateExpression<T> Not<T>(this PredicateExpression<T> predicate)
        {
            return Expression.Lambda<Func<T, bool>>(Expression.Not(predicate.Expression.Body), predicate.Expression.Parameters);
        }

        public static PredicateExpression<T> Create<T>(Expression<Func<T, bool>> expr)
        {
            return new PredicateExpression<T>(expr);
        }
    }
}
