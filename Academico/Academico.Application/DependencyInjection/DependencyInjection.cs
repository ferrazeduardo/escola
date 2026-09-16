using System;
using System.Reflection;
using Academico.Domain.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Academico.Application.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped<VerificadorDeVagaService>();
        return services;
    }
}
