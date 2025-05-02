using Microsoft.AspNetCore.SignalR.Client;

const string URL = "http://localhost:5142/chat";

/* =============================================================================================
 * await using é usado com objetos que implementam IAsyncDisposable, ou seja, que têm um método 
 * DisposeAsync() assíncrono. Quando o bloco atual (método, escopo, etc.) terminar, o 
 * DisposeAsync() será chamado automaticamente de forma assíncrona. 
 * ============================================================================================= */
await using var connection = new HubConnectionBuilder()
	.WithUrl(URL)// Passando a URL que irá ser usada
	.Build(); // Construindo a conexão com SignalR

// Se conectando ao servidor
await connection.StartAsync();

// Essa string "StreamingAsync" é o nome do método que iremos usar do server
await foreach (var date in connection.StreamAsync<DateTime>("StreamingAsync"))
{
	Console.WriteLine(date.ToString("HH:mm:ss - dd.MM.yyyy"));
}