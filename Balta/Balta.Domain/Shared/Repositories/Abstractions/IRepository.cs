using Balta.Domain.Shared.Aggregate.Abstractions;
using Balta.Domain.Shared.Entities;

namespace Balta.Domain.Shared.Repositories.Abstractions;

public interface IRepository<TEntity> where TEntity : IAggregateRoot;