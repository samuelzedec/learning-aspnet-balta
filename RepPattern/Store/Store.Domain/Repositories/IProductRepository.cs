using Store.Domain.Abstractions;
using Store.Domain.Entities;

namespace Store.Domain.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<Product?> GetByIdAsync(Specification<Product> specification, CancellationToken cancellationToken = default);
    Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);
}