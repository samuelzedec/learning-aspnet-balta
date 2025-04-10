using Microsoft.EntityFrameworkCore;
using RepositoryStore.Data;
using RepositoryStore.Models;
using RepositoryStore.Repositories;
using RepositoryStore.Repositories.Abstractions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

app.MapGet("/v1/products", async (CancellationToken token, IProductRepository repository)
    => Results.Ok(await repository.GetAllAsync(cancellationToken: token)));

app.MapGet("/v1/products/{id:int}", async (int id, Product product, CancellationToken token, IProductRepository repository) =>
{
    product.Id = id;
    return Results.Ok(await repository.GetByIdAsync(product, token));
});

app.MapPost("/v1/products", async (Product product, CancellationToken token, IProductRepository repository)
    => Results.Ok(await repository.CreateAsync(product, token)));

app.MapPut("/v1/products", async (Product product, CancellationToken token, IProductRepository repository)
    => Results.Ok(await repository.UpdateAsync(product, token)));

app.MapDelete("/v1/products", async (int id, CancellationToken token, IProductRepository repository) 
    =>
{
    var product = await repository.GetByIdAsync(new Product() { Id = id });
    return product is null
        ? Results.NotFound()
        : Results.Ok(await repository.DeleteAsync(product, token));
});

app.Run();