using Microsoft.EntityFrameworkCore;
using RepositoryStore.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();
app.MapGet("/v1/products", async (AppDbContext context) =>
{
    return await context.Products.ToListAsync();
});
app.MapPost("/v1/products", (AppDbContext context) => "Hello World!");
app.MapPut("/v1/products", (AppDbContext context) => "Hello World!");
app.MapDelete("/v1/products", (AppDbContext context) => "Hello World!");
app.Run();
