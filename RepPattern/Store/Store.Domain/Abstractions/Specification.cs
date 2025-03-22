using System.Linq.Expressions;

namespace Store.Domain.Abstractions;

public abstract class Specification<T> : ISpecification<T>
{
    public abstract Expression<Func<T, bool>> ToExpression();

    public bool IsSatisfiedBy(T entity)
    {
        var predicate = ToExpression().Compile();
        return predicate.Invoke(entity);
    }
}