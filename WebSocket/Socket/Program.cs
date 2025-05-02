using System.Net;
using System.Net.WebSockets;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseWebSockets(); // Habilitando o uso do WebSockets no Asp.Net 

app.Map("/", async context =>
{
	if (!context.WebSockets.IsWebSocketRequest) // Verificando se a requisição é do tipo WebSockets
		context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
	else
	{
		// Aceitando a requisição WebSockets
		using var webSocket = await context
			.WebSockets
			.AcceptWebSocketAsync();

		while (true)
		{
			var data = Encoding.ASCII.GetBytes($".NET Rocks -> {DateTime.UtcNow}");

			await webSocket.SendAsync(
				data, // Os dados que ele espera em Bytes
				WebSocketMessageType.Text, // Tipo da mensagem (se fosse JSON é do tipo Text também)
				true, // Quer dizer que essa mensagem acaba aqui
				CancellationToken.None
			);

			await Task.Delay(1000);
		}
	}
});


await app.RunAsync();