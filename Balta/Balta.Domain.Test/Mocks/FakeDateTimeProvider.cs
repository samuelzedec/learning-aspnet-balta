using Balta.Domain.Shared.Abstractions;

namespace Balta.Domain.Test.Mocks;

public class FakeDateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow { get; } = DateTime.UtcNow;
}