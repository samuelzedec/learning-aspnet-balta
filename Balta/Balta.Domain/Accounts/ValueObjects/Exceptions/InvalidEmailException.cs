using Balta.Domain.Shared.Exceptions;

namespace Balta.Domain.Accounts.ValueObjects.Exceptions;

public class InvalidEmailException(string message) 
    : DomainException(message);
