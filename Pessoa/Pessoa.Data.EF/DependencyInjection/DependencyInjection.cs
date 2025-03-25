using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pessoa.Application.Interface;
using Pessoa.Application.Interface.Repository;
using Pessoa.Data.EF.Repository;

namespace Pessoa.Data.EF.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddDataEf(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<PessoaDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IRedeRepository, RedeRepository>();

        services.AddScoped<IPessoaRepository, PessoaRepository>();
        return services;
    }
}