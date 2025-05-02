using System.Net.WebSockets;
using System.Text;

using var webSocket = new ClientWebSocket(); // Classe para gerenciar um WebSocket
await webSocket.ConnectAsync( // Estabelecnedo uma conexão ao nosso WebSocket
	new Uri("ws://localhost:5044"),
	CancellationToken.None
);

/* ===================================================================
 * Quando definimos um Array de Bytes, estamos reservando um espaço 
 * de memória para armazenar dados binários. 
 * 
 * No contexto de WebSockets (e outros protocolos de rede), os dados 
 * recebidos são representados como uma sequência de bytes, e o array 
 * que criamos funciona como um BUFFER para armazenar essa sequência 
 * temporariamente.
 * 
 * Para a máquina, esse array de bytes é simplesmente uma área de 
 * memória onde os dados binários são armazenados e podem ser processados 
 * posteriormente.
 * =================================================================== */
byte[] buffer = new byte[256];

// Fica em loop enquanto a conexão está aberta
while (webSocket.State == WebSocketState.Open)
{
	var result = await webSocket.ReceiveAsync(
		buffer,
		CancellationToken.None
	);

	// Verifica se o tipo da messagem é para fechar a conexão
	if (result.MessageType == WebSocketMessageType.Close)
		await webSocket.CloseAsync(
			WebSocketCloseStatus.NormalClosure, // É um status de como ta sendo fechado a conexão (nesse caso fechamento normal)
			null, // Pode ser uma string explicando o motivo (aqui não tem)
			CancellationToken.None
		);
	else
		Console.WriteLine(Encoding.ASCII.GetString(
			buffer, // Este é o array de bytes que contém os dados a serem convertidos em string.
			0, // Este é o índice inicial a partir do qual a conversão deve começar dentro do buffer.
			result.Count) // Esse é o número de bytes que devem ser convertidos a partir do buffer.
		);
}  
