using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TrueCode.Application.Interfaces;
using TrueCode.Application.User;

namespace TrueCode.Application;
public static class ServiceRegistrar
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
