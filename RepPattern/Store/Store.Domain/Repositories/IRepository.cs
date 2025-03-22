using Store.Domain.Abstractions;

namespace Store.Domain.Repositories;

public interface IRepository<T> where T : IAggregateRoot;