using Api.Chat.Models;

namespace Api.Chat.Hubs;
public interface IHubProvider
{
    Task ReceivedMessage(Message message);
}