using Api.Chat.Models;
using Microsoft.AspNetCore.SignalR;

namespace Api.Chat.Hubs;

/* ============================================================================
 * A interface passada para Hub<T> não é para o servidor chamar, mas sim 
 * para definir os métodos que o servidor vai invocar nos clientes conectados.
 * ============================================================================ */
public class HubProvider : Hub<IHubProvider>
{
    public async Task SendMessage(Message message)
    {
        // Envia para todos os clientes conectados
        await Clients.All.ReceivedMessage(message);
    }
}