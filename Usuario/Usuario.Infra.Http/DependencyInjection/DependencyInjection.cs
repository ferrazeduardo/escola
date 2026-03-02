using System;
using Microsoft.Extensions.DependencyInjection;
using Usuario.Domain.Interface.HttpClients;
using Usuario.Infra.Http.HttpClients;

namespace Usuario.Infra.Http.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraHttp(this IServiceCollection services)
    {
        services.AddHttpClient<IRedeClient,RedeClient>();
        return services;
    }
}
