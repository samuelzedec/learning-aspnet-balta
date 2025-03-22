using Microsoft.EntityFrameworkCore;
using Store.Domain.Abstractions;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Infrastructure.Data;

namespace Store.Infrastructure.Repositories;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public async Task<Product?> GetByIdAsync(Specification<Product> specification,
        CancellationToken cancellationToken = default)
        => await context
            .Products
            .AsNoTracking()
            .FirstOrDefaultAsync(specification.ToExpression(),cancellationToken);

    public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
        await context.Products.AddAsync(product, cancellationToken);
        return product;
    }
}