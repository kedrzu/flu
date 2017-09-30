using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Flu
{
    public static class ExpressionHelper
    {
        public static Expression<Func<T, bool>> Or<T>(LambdaExpression expr1, LambdaExpression expr2)
        {
            var invoked = Expression.Invoke(expr2, expr1.Parameters);
            var left = Expression.OrElse(expr1.Body, invoked);

            return Expression.Lambda<Func<T, bool>>(left, expr1.Parameters);
        }

        public static Expression<Func<T, bool>> Or<T>(Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            return Or<T>((LambdaExpression) expr1, expr2);
        }

        public static Expression<Func<T, bool>> And<T>(LambdaExpression expr1, LambdaExpression expr2)
        {
            var invoked = Expression.Invoke(expr2, expr1.Parameters);
            var left = Expression.AndAlso(expr1.Body, invoked);

            return Expression.Lambda<Func<T, bool>>(left, expr1.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            return And<T>((LambdaExpression)expr1, expr2);
        }
        
        public static Expression<Func<T, bool>> Not<T>(LambdaExpression expr)
        {
            return Expression.Lambda<Func<T, bool>>(Expression.Not(expr.Body), expr.Parameters);
        }

        public static Expression<Func<T, bool>> Not<T>(Expression<Func<T, bool>> expr)
        {
            return Not<T>((LambdaExpression) expr);
        }
    }
}
