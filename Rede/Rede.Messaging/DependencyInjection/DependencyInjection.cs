using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using Rede.Messaging.Configuration;

namespace Rede.Messaging.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddRabbitMQ(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<RabbitMQConfiguration>(
            configuration.GetSection(RabbitMQConfiguration.ConfigurationSection));
        

        services.AddSingleton(sp =>
        {
            RabbitMQConfiguration config = sp
                .GetRequiredService<IOptions<RabbitMQConfiguration>>().Value;
            var factory = new ConnectionFactory
            {
                HostName = config.Hostname,
                UserName = config.Username,
                Password = config.Password,
                Port = config.Port
            };
            return factory.CreateConnection();
        });

        services.AddSingleton<ChannelManager>();

        return services;
    }
}