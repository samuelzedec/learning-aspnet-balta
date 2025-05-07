using Balta.Domain.Shared.Entities;

namespace Balta.Domain.Accounts.Entities;

public sealed class Student : Entity
{
    #region Constructors

    public Student(string firstName, string lastName, string email, string password) 
        : base(Guid.CreateVersion7())
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    #endregion
    
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Password { get; }
}