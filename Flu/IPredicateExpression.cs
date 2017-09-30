using System.Linq.Expressions;

namespace Flu
{
    /// <summary>
    /// Base interface for predicates. 
    /// 
    /// This is mostly to keep predicates contravariant, 
    /// the same way basic expressions are.
    /// </summary>
    public interface IPredicateExpression<in T>
    {
        LambdaExpression Expression { get; }
    }
}