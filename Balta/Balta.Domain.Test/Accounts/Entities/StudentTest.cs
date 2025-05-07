using Balta.Domain.Accounts.Entities;

namespace Balta.Domain.Test.Accounts.Entities;

public class StudentTest
{
    [Fact]
    public void Test1()
    {
        var student = new Student(
            "Samuel",
            "Zedec",
            "samuelzedec@gmail.com",
            "12345678"
        );
        
        
    }
}