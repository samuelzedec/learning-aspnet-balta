using Microsoft.EntityFrameworkCore;
using MediatR;
using Store.Application;
using Store.Infrastructure;
using Store.Infrastructure.Data;
using GetById = Store.Application.UseCases.Products.GetById;
using Create = Store.Application.UseCases.Products.Create;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        x => x.MigrationsAssembly("Store.Api"));
});

builder.Services.AddApplication();
builder.Services.AddInfrasctruture();

var app = builder.Build();

app.MapGet("/", () => "Health Check!");

app.MapGet("v1/products/{id:Guid}", async (
    ISender sender,
    Guid id,
    CancellationToken cancellationToken) =>
{
    var command = new GetById.Command(id);
    var result = await sender.Send(command, cancellationToken);

    return result.IsSuccess
        ? Results.Ok(result.Value)
        : Results.BadRequest(result.Error);
});

app.MapPost("v1/products", async (
    ISender sender,
    Create.Command command,
    CancellationToken cancellationToken) =>
{
    var result = await sender.Send(command, cancellationToken);
    return result.IsSuccess
        ? Results.Ok(result.Value)
        : Results.BadRequest(result.Error);
});

app.Run();