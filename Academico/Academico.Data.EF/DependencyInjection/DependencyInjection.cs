using System;
using Academico.Data.EF.Repository;
using Academico.Domain.Interface;
using Academico.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Academico.Data.EF.DependencyInjection;

public static class DependencyInjection
{

    public static IServiceCollection AddDataEf(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPessoaRepository, PessoaRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<AcademicoDbContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }

}
