namespace Api.Chat.Models;
public class Message(string name, string body)
{
    public string Name { get; init; } = name;
    public string Body { get; init; } = body;
    public string Date { get; } = DateTime.Now.ToString("G");
}