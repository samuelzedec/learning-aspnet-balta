using Store.Domain.Abstractions;

namespace Store.Domain.Entities;

public class Product : Entity, IAggregateRoot
{
    public string Title { get; set; } = string.Empty;
}