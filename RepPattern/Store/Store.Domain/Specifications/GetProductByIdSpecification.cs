using System.Linq.Expressions;
using Store.Domain.Abstractions;
using Store.Domain.Entities;

namespace Store.Domain.Specifications;

public class GetProductByIdSpecification(Guid id) : Specification<Product>
{
    public override Expression<Func<Product, bool>> ToExpression()
        => product => product.Id == id;
}