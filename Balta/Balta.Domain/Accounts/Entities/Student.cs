using Balta.Domain.Accounts.ValueObjects;
using Balta.Domain.Shared.Entities;

namespace Balta.Domain.Accounts.Entities;

public sealed class Student : Entity
{
    #region Constructors

    public Student(string firstName, string lastName, string email, string password)
        : base(Guid.CreateVersion7())
    {
        Name = Name.Create(firstName, lastName);
        Email = email;
        Password = password;
    }

    #endregion

    #region Properties

    public Name Name { get; }
    public string Email { get; }
    public string Password { get; }

    #endregion
}