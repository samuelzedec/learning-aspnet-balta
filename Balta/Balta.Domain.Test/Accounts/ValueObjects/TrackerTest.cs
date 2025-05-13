using Balta.Domain.Accounts.ValueObjects;
using Balta.Domain.Shared.Abstractions;
using Balta.Domain.Test.Mocks;

namespace Balta.Domain.Test.Accounts.ValueObjects;

public class TrackerTest
{
    private readonly IDateTimeProvider _mockDateTimeProvider = new FakeDateTimeProvider();
    
    [Fact]
    public void ShouldCreateTrackerWithCurrentUtcDateTime()
    {
        var tracker = Tracker.Create(_mockDateTimeProvider);
        Assert.Equal(_mockDateTimeProvider.UtcNow, tracker.CreatedAt);
    }
}