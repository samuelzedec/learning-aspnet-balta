using Balta.Domain.Shared.Exceptions;

namespace Balta.Domain.Accounts.Exceptions;

public class InvalidNameException(string message) 
    : DomainException(message);