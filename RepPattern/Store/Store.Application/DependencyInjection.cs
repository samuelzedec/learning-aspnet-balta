using Microsoft.Extensions.DependencyInjection;

namespace Store.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddMediatR(mediat 
            => mediat.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        return service;
    }
}