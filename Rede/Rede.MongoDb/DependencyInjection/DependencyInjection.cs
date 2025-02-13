using Microsoft.Extensions.DependencyInjection;
using Rede.Domain.Interfaces.Repository;
using Rede.MongoDb.Model;
using Rede.MongoDb.Repository;

namespace Rede.MongoDb.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddMongo(this IServiceCollection services)
    {
        services.AddScoped<MongoDBContext>();
        services.AddScoped<IRedeRepository, RedeRepository>();
        return services;
    }
}