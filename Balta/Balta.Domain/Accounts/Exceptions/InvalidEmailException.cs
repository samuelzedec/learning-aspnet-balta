using Balta.Domain.Shared.Exceptions;

namespace Balta.Domain.Accounts.Exceptions;

public class InvalidEmailException(string message) 
    : DomainException(message);
