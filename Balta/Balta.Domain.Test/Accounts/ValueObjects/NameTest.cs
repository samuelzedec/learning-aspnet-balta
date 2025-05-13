using Balta.Domain.Accounts.ValueObjects.Exceptions;
using Balta.Domain.Accounts.ValueObjects;

namespace Balta.Domain.Test.Accounts.ValueObjects;

public class NameTest
{
    private readonly Name _name = Name.Create("Samuel", "Zedec");

    [Fact]
    public void ShouldOverrideToStringMethod()
    {
        Assert.Equal("Samuel Zedec", _name.ToString());
    }

    [Fact]
    public void ShouldImplicitConvertToString()
    {
        string data = _name;
        Assert.Equal("Samuel Zedec", data);
    }

    [Fact]
    public void ShouldFailFirstNameLengthIsNotValid()
    {
        Assert.Throws<InvalidFirstNameLengthException>(() =>
        {
            var name = Name.Create("S", "Zedec");
        });
    }
}