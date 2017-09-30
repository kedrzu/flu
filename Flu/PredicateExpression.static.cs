using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Flu
{
    public static class PredicateExpression
    {
        /// <summary>
        /// Predicate always being true
        /// </summary>
        public static PredicateExpression<object> True = new PredicateExpression<object>(f => true);

        /// <summary>
        /// Predicate always being false
        /// </summary>
        public static PredicateExpression<object> False = new PredicateExpression<object>(f => false);

        /// <summary>
        /// Creates a composite predicate with alternative (OR) operator.
        /// </summary>
        /// <param name="predicate1">First predicate</param>
        /// <param name="predicate2">Second predicate</param>
        /// <returns>New predicate being a composite of the given two</returns>
        public static PredicateExpression<T> Or<T>(this IPredicateExpression<T> predicate1, PredicateExpression<T> predicate2)
        {
            return ExpressionHelper.Or<T>(predicate1.Expression, predicate2.Expression);
        }

        /// <summary>
        /// Creates a composite predicate with alternative (OR) operator.
        /// </summary>
        /// <param name="predicate1">First predicate</param>
        /// <param name="predicate2">Second predicate</param>
        /// <returns>New predicate being a composite of the given two</returns>
        public static PredicateExpression<T> Or<T>(this IPredicateExpression<T> predicate1, IPredicateExpression<T> predicate2)
        {
            return ExpressionHelper.Or<T>(predicate1.Expression, predicate2.Expression);
        }

        /// <summary>
        /// Creates a composite predicate with conjunction (AND) operator.
        /// </summary>
        /// <param name="predicate1">First predicate</param>
        /// <param name="predicate2">Second predicate</param>
        /// <returns>New predicate being a composite of the given two</returns>
        public static PredicateExpression<T> And<T>(this IPredicateExpression<T> predicate1, PredicateExpression<T> predicate2)
        {
            return ExpressionHelper.And<T>(predicate1.Expression, predicate2.Expression);
        }

        /// <summary>
        /// Creates a composite predicate with conjunction (AND) operator.
        /// </summary>
        /// <param name="predicate1">First predicate</param>
        /// <param name="predicate2">Second predicate</param>
        /// <returns>New predicate being a composite of the given two</returns>
        public static PredicateExpression<T> And<T>(this IPredicateExpression<T> predicate1, IPredicateExpression<T> predicate2)
        {
            return ExpressionHelper.And<T>(predicate1.Expression, predicate2.Expression);
        }

        /// <summary>
        /// Creates a negated predicate.
        /// </summary>
        /// <param name="predicate">Predicate to negate</param>
        /// <returns>New predicate being a negation of the given predicate</returns>
        public static PredicateExpression<T> Not<T>(this PredicateExpression<T> predicate)
        {
            return ExpressionHelper.Not(predicate.Expression);
        }

        /// <summary>
        /// Creates a new predicate.
        /// </summary>
        /// <param name="expression">Expression to create predicate from</param>
        /// <returns>Newly created predicate</returns>
        public static PredicateExpression<T> Create<T>(Expression<Func<T, bool>> expression)
        {
            return new PredicateExpression<T>(expression);
        }
    }
}
