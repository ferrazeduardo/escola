using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rede.Data.EF.Repository;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Data.EF;

public static class DependencyInjection
{
    public static IServiceCollection AddDataEf(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IRedeRepository, RedeRepository>();
        return services;
    }
}