using Todo.Data;

var builder = WebApplication.CreateBuilder(args);

// Registrando os controladores da aplicação para que ASP.NET Core saiba como rotear e processar as requisições para eles
builder.Services.AddControllers();

// Adiciona o AppDataContext aos serviços do ASP.NET Core para ser gerenciado pelo Dependency Injection (DI),
// permitindo que ele controle a configuração e o ciclo de vida da conexão com o banco de dados.
builder.Services.AddDbContext<AppDataContext>();


var app = builder.Build();
app.MapControllers(); // Aqui ele irá mapear todas as classes que herdam de Controller ou ControllerBase
app.Run();
