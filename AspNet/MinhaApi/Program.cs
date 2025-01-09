var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => {
	return Results.Ok("Hello, World!");
	//Results é usado para retornar o Status que queremos com a mensagem que queremos
});

// As chaves na URL são os parâmetros e a váriavel nome irá guardar esse valor passado pela URL
app.MapGet("/name/{nome}", (string nome) => {
	return Results.Ok($"Hello, {nome}!");
	// Resultado na rota: http://localhost:5243/samuel
});

app.MapPost("/", (User user) => {
	return Results.Ok(user);
});

app.Run();


public class User 
{
	public int Id { get; set; }
	public string? Username { get; set; }
}