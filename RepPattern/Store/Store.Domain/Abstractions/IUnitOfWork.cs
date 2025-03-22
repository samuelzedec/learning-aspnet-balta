namespace Store.Domain.Abstractions;

public interface IUnitOfWork
{
    Task CommitAsync();
}