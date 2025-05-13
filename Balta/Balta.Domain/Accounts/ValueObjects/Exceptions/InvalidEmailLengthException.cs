using Balta.Domain.Shared.Exceptions;

namespace Balta.Domain.Accounts.ValueObjects.Exceptions;

public class InvalidEmailLengthException(string message) 
    : DomainException(message);