using Microsoft.Extensions.DependencyInjection;

namespace TrueCode.Infrastructure;
public static class ServiceRegistrar
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<DatabaseContext>();
        return services;
    }
}
