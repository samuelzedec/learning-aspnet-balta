namespace WebBlog;

public static class Configuration
{
    public static string JwtKey { get; set; } = Guid.NewGuid().ToString();
    public static string ApiKeyName { get; set; } = "api_key";
    public static string ApiKey { get; set; } = "api_key_comunication";
}