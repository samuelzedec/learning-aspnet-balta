using Balta.Domain.Shared.Exceptions;

namespace Balta.Domain.Accounts.Exceptions;

public class InvalidEmailLengthException(string message) 
    : DomainException(message);