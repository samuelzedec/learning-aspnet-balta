namespace Balta.Domain.Shared.Entities;

/* --------------------------------------------------------------------------------------
 * A interface IEquatable<T> permite implementar um método de comparação
 * tipado sem substituir completamente o método Equals padrão que vem da classe Object.
 * -------------------------------------------------------------------------------------- */
public abstract class Entity(Guid id) : IEquatable<Guid>
{
    #region Properties

    public Guid Id { get; } = id;

    #endregion

    #region Equatable Implementation

    public bool Equals(Guid id)
        => Id == id;

    public override int GetHashCode()
        => Id.GetHashCode();

    #endregion
}