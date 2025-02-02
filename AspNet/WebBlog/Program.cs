using System.IO.Compression;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebBlog;
using WebBlog.Data;
using WebBlog.Services;

var builder = WebApplication.CreateBuilder(args);
ConfigureAuthentication(builder);
ConfigureMvc(builder);
ConfigureServices(builder);

// a API só deve ser construída depois que o builder adicionar os controllers e o DbContext
var app = builder.Build();
LoadConfiguration(app);

app.UseHttpsRedirection(); // Fará com que ao usar a nossa url irá ser redirecionando para https em vez de http
app.UseAuthentication(); // Faz com que o asp.net necessite de autorização
app.UseAuthorization(); // ativa para o asp.net usar autenticação
app.UseResponseCompression(); // Para ativar o uso da compressão
app.MapControllers();
app.UseStaticFiles(); // Para usar com arquivos estáticos, irá sempre procurar a pasta wwwroot

if (app.Environment.IsDevelopment()) //  Irá retornar um boolean dizendo se realmente estamos em desenvolvimento
{
    app.UseSwagger(); // estamos habilitando o swagger 
    app.UseSwaggerUI(); // estmoas habilitando a interface do swagger
}

app.Run("https://localhost:8000/");

void LoadConfiguration(WebApplication app)
{
    Configuration.JwtKey = app.Configuration.GetValue<string>("JwtKey") ?? "";
    Configuration.ApiKeyName = app.Configuration.GetValue<string>("ApiKeyName");
    Configuration.ApiKey = app.Configuration.GetValue<string>("ApiKey");

    var smtp = new Configuration.SmtpConfiguration();
    app.Configuration.GetSection("Smtp").Bind(smtp);
    // Ao adicionar o .Bind() o asp.net irá converter a seção e popular o classe 
    Configuration.Smtp = smtp;
}

void ConfigureAuthentication(WebApplicationBuilder builder)
{
    var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
        //Isso significa que todas as requisições protegidas vão tentar autenticar usando tokens JWT.
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; 
        // Define o esquema que será usado para desafios de autenticação. Por exemplo, se um usuário não autenticado
        // tentar acessar um recurso, o sistema saberá que precisa usar JWT para tratá-lo.
    }).AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new()
        {
            ValidateIssuerSigningKey = true, // Irá validar a chave assinatura
            IssuerSigningKey = new SymmetricSecurityKey(key), // E como ele valida, irá usar o mesmo algortimo configurado na chave
            ValidateIssuer = false,
            ValidateAudience = false
        };
        
        x.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                // Aqui você pode verificar mais detalhadamente o erro
                Console.WriteLine($"Token inválido: {context.Exception.Message}");
                return Task.CompletedTask;
            }
        };
    });
    /*Usamos isso para fazer a configuração do DataAnnotation [Authorize], sem isso ele não funcionária*/
}

void ConfigureMvc(WebApplicationBuilder builder)
{
    builder.Services.AddEndpointsApiExplorer(); // Habilita a descoberta e mapeamento dos endpoints da API para o Swagger
    builder.Services.AddSwaggerGen(); // Habilita a geração do Swagger e Swagger UI
    builder.Services.AddMemoryCache(); // Irá adicionar o uso de cache ao Asp.Net Core
    builder.Services.AddResponseCompression(options =>
    {
        options.EnableForHttps = true; // Habilita a compressão também para HTTPS
        // options.Providers.Add<BrotliCompressionProvider>();
        options.Providers.Add<GzipCompressionProvider>(); // Usa o Gzip como provedor de compressão
        // options.Providers.Add<CustomCompressionProvider>();
        options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json", "text/html" });
        // Configura os tipos de conteúdo que terão compressão (JSON e HTML)

    }); // Aqui iremos definir qual tipo de comprensão usar
    
    builder.Services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal); 
    /*
     * Isso configura o nível de compressão do Gzip. O CompressionLevel.Optimal oferece um bom equilíbrio entre
     * velocidade e taxa de compressão, sendo geralmente a melhor escolha para a maioria dos cenários.
     */
    
    builder.Services
        .AddControllers()
        .ConfigureApiBehaviorOptions(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
            // Isso irá desabilitar a verficação automática do Asp.Net
        })
        .AddJsonOptions(x =>
        {
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; // Faz com que ignore ciclos subsequentes nas serializações
            x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault; // Caso o objeto seja nulo ele não irá serializar
        });
}

void ConfigureServices(WebApplicationBuilder builder) 
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<BlogDataContext>(options =>
    {
        options.UseSqlServer(connectionString);
    });
    builder.Services.AddTransient<TokenService>(); // Sempre irá criar uma nova instância onde for pedido
    builder.Services.AddTransient<EmailService>();
}