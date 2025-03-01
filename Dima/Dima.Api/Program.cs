using Dima.Api.Data;
using Dima.Core.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.CustomSchemaIds(n => n.FullName);
});

var connectionString = builder
    .Configuration
    .GetConnectionString("DefaultConnection") ?? string.Empty;
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
builder.Services.AddTransient<Handler>();

var app = builder.Build();

app.MapPost(
    "/v1/categories", 
    (Request request, Handler handler) 
        => handler.Handle(request))
    .WithName("Category: Create")
    .WithSummary("Cria um nova categoria")
    .Produces<Response>();

app.UseSwagger();
app.UseSwaggerUI();
app.Run();

public record Request
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
};

public record Response
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
}

public class Handler(AppDbContext context)
{
    public async Task<Response> Handle(Request request)
    {
        var category = new Category
        {
            Title = request.Title,
            Description = request.Description
        };

        await context.Categories.AddAsync(category);
        await context.SaveChangesAsync();
        
        return new Response
        {
            Id = category.Id,
            Title = category.Title
        };
    }
}