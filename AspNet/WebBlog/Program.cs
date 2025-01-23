using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebBlog;
using WebBlog.Data;
using WebBlog.Services;

var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; //Isso significa que todas as requisições protegidas vão tentar autenticar usando tokens JWT.
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // Define o esquema que será usado para desafios de autenticação. Por exemplo, se um usuário não autenticado tentar acessar um recurso, o sistema saberá que precisa usar JWT para tratá-lo.
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new()
    {
        ValidateIssuerSigningKey = true, // Irá validar a chave assinatura
        IssuerSigningKey = new SymmetricSecurityKey(key), // E como ele valida, irá usar o mesmo algortimo configurado na chave
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
        // Isso irá desabilitar a verficação automática do Asp.Net
    });
builder.Services.AddDbContext<BlogDataContext>();

builder.Services.AddTransient<TokenService>(); // Sempre irá criar uma nova instância onde for pedido

// a API só deve ser construída depois que o builder adicionar os controllers e o DbContext
var app = builder.Build();
app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run("https://localhost:8000/");
