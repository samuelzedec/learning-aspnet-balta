using System.Net;
using System.Net.Mail;
namespace WebBlog.Services;

public class EmailService
{
    public bool Send(
        string toName,
        string toEmail,
        string subject,
        string body,
        string fromName = "Samuel Zedec",
        string fromEmail = "contact@samuelzedec.tech")
    {
        var smtpClient = new SmtpClient(Configuration.Smtp.Host, Configuration.Smtp.Port) // Configurando a conexão
        {
            Credentials = new NetworkCredential(Configuration.Smtp.Username, Configuration.Smtp.Password), // Passando as credenciais
            DeliveryMethod = SmtpDeliveryMethod.Network, // significa que o e-mail será enviado via rede (para servidores de e-mail)
            EnableSsl = true // Habilita ou desabilita a segurança SSL (SSL é um protocolo de segurança)
        };

        var mail = new MailMessage()
        {
            From = new MailAddress(fromEmail, fromName),
            To = { new MailAddress(toEmail, toName) },
            Subject = subject,
            Body = body,
            IsBodyHtml = true // Faz com que seja aceito tags html
        };

        try
        {
            smtpClient.Send(mail);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }
}