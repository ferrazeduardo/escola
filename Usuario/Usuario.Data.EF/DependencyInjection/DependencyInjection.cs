using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Usuario.Data.EF.Repository;
using Usuario.Domain.Interface;
using Usuario.Domain.Interface.Repository;

namespace Usuario.Data.EF.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddDataEf(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<IUsuarioRepository,UsuarioRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<UsuarioDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        return services;
    }
}
