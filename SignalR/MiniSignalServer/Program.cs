using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR(); // Habilidando o uso do SignalR com AspNet


var app = builder.Build();
app.MapHub<MyHub>("/chat");
app.MapGet("/", () => "Hello World!");

app.Run();

public class MyHub : Hub
{
	/* =============================================================================================
	 * IAsyncEnumerable<T>: Em C#, IAsyncEnumerable<T> representa uma coleção assíncrona 
	 * que pode ser iterada item por item com await foreach, de forma parecida com IEnumerable<T>, 
	 * mas sem bloquear a thread.
	 *
	 * yield return: O yield return faz o método retornar um valor e "pausar" a execução até que você 
	 * peça o próximo valor. Quando você pede novamente, ele retoma a execução do ponto onde parou 
	 * (no caso, após o Task.Delay), realizando o que é necessário (como o delay) antes de retornar 
	 * o próximo valor.
	 * ============================================================================================= */
	public async IAsyncEnumerable<DateTime> StreamingAsync(
		[EnumeratorCancellation] CancellationToken cancellationToken)
	{
		/* =============================================================================================
		 * O atributo [EnumeratorCancellation] indica ao compilador que o token de cancelamento passado 
		 * como parâmetro deve ser propagado para o enumerador assíncrono gerado automaticamente 
		 * pelo método async iterator. 
		 * ============================================================================================= */
		while (true)
		{
			yield return DateTime.UtcNow;
			await Task.Delay(1000, cancellationToken);
		}
	}
}