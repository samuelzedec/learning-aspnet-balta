using Balta.Domain.Shared.Exceptions;

namespace Balta.Domain.Accounts.ValueObjects.Exceptions;

public sealed class InvalidFirstNameLengthException(string message = "First name is not valid.") 
    : DomainException(message);