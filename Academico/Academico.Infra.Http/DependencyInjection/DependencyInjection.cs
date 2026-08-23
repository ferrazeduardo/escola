using System;
using Academico.Domain.Interface.HttpClients;
using Academico.Infra.Http.HttpClients;
using Microsoft.Extensions.DependencyInjection;


namespace Academico.Infra.Http.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraHttp(this IServiceCollection service)
    {
        service.AddHttpClient<IUnidadeClient, UnidadeClient>();
        return service;
    }

}
