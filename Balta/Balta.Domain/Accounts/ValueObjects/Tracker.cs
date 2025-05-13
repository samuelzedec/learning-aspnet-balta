using Balta.Domain.Shared.Abstractions;
using Balta.Domain.Shared.ValueObjects;

namespace Balta.Domain.Accounts.ValueObjects;

public sealed record Tracker : ValueObject
{
    #region Constructors

    private Tracker(DateTime createdAtUtc, DateTime updatedAtUtc)
    {
        CreatedAt = createdAtUtc;
        UpdatedAt = updatedAtUtc;
    }

    #endregion

    #region Factories

    public static Tracker Create(IDateTimeProvider dateTimeProvider)
        => new Tracker(dateTimeProvider.UtcNow, dateTimeProvider.UtcNow);

    public static Tracker Create(DateTime createdAtUtc, DateTime updatedAtUtc)
        => new Tracker(createdAtUtc, updatedAtUtc);

    #endregion

    #region Properties

    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; private set; }

    #endregion

    #region Public Methods

    public void Update(IDateTimeProvider dateTimeProvider)
        => UpdatedAt = dateTimeProvider.UtcNow;

    #endregion
}