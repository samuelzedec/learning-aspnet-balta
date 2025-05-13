using Balta.Domain.Shared.Exceptions;

namespace Balta.Domain.Accounts.ValueObjects.Exceptions;

public sealed class InvalidLastNameLengthException(string message = "Last name is not valid.") 
    : DomainException(message);