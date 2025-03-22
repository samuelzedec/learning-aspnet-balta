using Microsoft.Extensions.DependencyInjection;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrasctruture(this IServiceCollection service)
    {
        service.AddScoped<IProductRepository, ProductRepository>();
        service.AddTransient<IUnitOfWork, UnitOfWork>();
        return service;
    }
}