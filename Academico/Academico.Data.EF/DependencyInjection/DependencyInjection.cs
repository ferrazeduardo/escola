using System;
using Academico.Data.EF.Repository;
using Academico.Domain.Interface.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Academico.Data.EF.DependencyInjection;

public static class DependencyInjection
{

    public static IServiceCollection AddDataEf(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPessoaRepository, PessoaRepository>();
        

        return services;
    }

}
