using Balta.Domain.Accounts.ValueObjects.Exceptions;
using Balta.Domain.Shared.ValueObjects;

namespace Balta.Domain.Accounts.ValueObjects;
public sealed record Name : ValueObject
{

    #region Constants

    public const int MinLength = 3;
    public const int MaxLength = 60;

    #endregion

    #region Constructors

    private Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    #endregion

    #region Factories
    /* ----------------------------------------------------------------------------------
    * Ao usar uma factory para criar a instância, podemos aplicar regras de negócio
    * nesta camada em vez de no construtor da entidade. Isso é benéfico porque:
    *
    * 1. O EF Core usa o construtor ao materializar entidades do banco,
    *    e regras complexas no construtor podem impactar o desempenho ou causar erros
    *
    * 2. Separa as responsabilidades: a entidade representa o modelo, enquanto
    *    a factory implementa as regras de criação da entidade
    *
    * 3. Facilita os testes unitários ao centralizar a lógica de criação
    * ---------------------------------------------------------------------------------- */

    public static Name Create(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            throw new InvalidNameException("Name cannot be empty");
        
        if (firstName.Length is < MinLength or > MaxLength)
            throw new InvalidFirstNameLengthException();

        if (lastName.Length is < MinLength or > MaxLength)
            throw new InvalidLastNameLengthException();

        return new Name(firstName, lastName);
    }

    #endregion

    #region Properties

    public string FirstName { get; set; }
    public string LastName { get; set; }

    #endregion

    #region Operators

    public static implicit operator string(Name name)
        => name.ToString();

    #endregion

    #region Overrides

    public override string ToString()
        => $"{FirstName} {LastName}";

    #endregion
}