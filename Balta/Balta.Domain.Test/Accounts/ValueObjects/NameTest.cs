using Balta.Domain.Accounts.ValueObjects;

namespace Balta.Domain.Test.Accounts.ValueObjects;

public class NameTest
{
    private readonly string _name = new Name("Samuel", "Zedec");
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
}