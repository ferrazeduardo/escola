using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Usuario.Application.Service;
using Usuario.Domain.Interface.Service;

namespace Usuario.Application.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped<ITokenService, TokenService>();
        return services;
    }
}