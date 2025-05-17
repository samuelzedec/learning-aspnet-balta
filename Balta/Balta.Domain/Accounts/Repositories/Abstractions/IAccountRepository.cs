using Balta.Domain.Accounts.Entities;
using Balta.Domain.Shared.Repositories.Abstractions;

namespace Balta.Domain.Accounts.Repositories.Abstractions;

public interface IAccountRepository : IRepository<Student>
{
    Task CreateAsync(Student student, CancellationToken cancellationToken = default);
}