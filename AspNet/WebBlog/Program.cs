using WebBlog.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
        // Isso irá desabilitar a verficação automática do Asp.Net
    });
builder.Services.AddDbContext<BlogDataContext>();

// a API só deve ser construída depois que o builder adicionar os controllers e o DbContext
var app = builder.Build();
app.MapControllers();
app.Run("https://localhost:8000/");
