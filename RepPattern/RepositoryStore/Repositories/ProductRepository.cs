using Microsoft.EntityFrameworkCore;
using RepositoryStore.Data;
using RepositoryStore.Models;
using RepositoryStore.Repositories.Abstractions;

namespace RepositoryStore.Repositories;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
        await context.Products.AddAsync(product, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return product;
    }

    public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default)
    {
        context.Products.Update(product);
        await context.SaveChangesAsync(cancellationToken);
        return product;
    }
    
    public async Task<Product> DeleteAsync(Product product, CancellationToken cancellationToken = default)
    {
        context.Products.Remove(product);
        await context.SaveChangesAsync(cancellationToken);
        return product;
    }
    
    public async Task<Product?> GetByIdAsync(Product product, CancellationToken cancellationToken = default)
    {
        return await context
            .Products
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == product.Id, cancellationToken);
    }
    
    public async Task<List<Product>?> GetAllAsync(
        int skip = 1, 
        int take = 25, 
        CancellationToken cancellationToken = default)
    {
        return await context
            .Products
            .AsNoTracking()
            .Skip(take * (skip - 1))
            .Take(take)
            .ToListAsync(cancellationToken);
    }
    
}