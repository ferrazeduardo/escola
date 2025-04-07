using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Rede.Data.EF;

public static class DependencyInjection
{
    public static IServiceCollection AddDataEf(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}