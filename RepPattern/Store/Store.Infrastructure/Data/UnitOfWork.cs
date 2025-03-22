using Store.Domain.Abstractions;

namespace Store.Infrastructure.Data;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CommitAsync()
        => await context.SaveChangesAsync();
}