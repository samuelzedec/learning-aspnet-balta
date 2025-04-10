namespace Solid._05_DIP.Bad;

public class EmailService
{
    public void Send(){}
}

public class UserService(EmailService service)
{
    
}