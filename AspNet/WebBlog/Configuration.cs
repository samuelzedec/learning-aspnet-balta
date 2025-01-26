namespace WebBlog;

public static class Configuration
{
    /*É bom usar os mesmo nomes da chaves nas prpriedades*/
    public static string JwtKey { get; set; } = "Z2xvYmFsLXRlc3Qta2V5LTEyMw=DMWdkgW35/34wqa3Qta2==";
    public static string? ApiKeyName { get; set; } 
    public static string? ApiKey { get; set; }
    public static SmtpConfiguration Smtp = new ();
    
    public class SmtpConfiguration
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}