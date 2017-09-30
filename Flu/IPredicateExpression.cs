using System.Linq.Expressions;

namespace Flu
{
    public interface IPredicateExpression<in T>
    {
        LambdaExpression Expression { get; }
    }
}