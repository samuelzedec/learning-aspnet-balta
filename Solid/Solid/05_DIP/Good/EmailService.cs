namespace Solid._05_DIP.Good;

public interface IEmailService
{
    void Send();
}

public class EmailService : IEmailService
{
    public void Send()
    {
        Console.WriteLine("E-mail enviado!");
    }
}

public class FakeEmailService : IEmailService
{
    public void Send()
    {
        Console.WriteLine("Fake E-mail enviado!");
    }
}

public class UserService(IEmailService service)
{
    
}
