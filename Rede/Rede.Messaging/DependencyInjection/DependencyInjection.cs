using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using Rede.Domain.Interfaces.Application;
using Rede.Messaging.Configuration;
using Rede.Messaging.Producer;

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
        services.AddTransient<IMessageProducer>(sp =>
        {
            var channelManager = sp.GetRequiredService<ChannelManager>();
            var config = sp.GetRequiredService<IOptions<RabbitMQConfiguration>>();
            return new RabbitMQProducer(channelManager.GetChannel(), config);
        });
        return services;
    }
}