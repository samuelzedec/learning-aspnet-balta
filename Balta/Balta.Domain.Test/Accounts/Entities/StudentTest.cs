using Balta.Domain.Accounts.Entities;
using Balta.Domain.Test.Mocks;

namespace Balta.Domain.Test.Accounts.Entities;

public class StudentTest
{
    [Fact]
    public void Test1()
    {
        var student = Student.Create(
            "Samuel",
            "Zedec",
            "samuelzedec@gmail.com",
            new FakeDateTimeProvider()
        );
    }
}