using System.Text.Json;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using Rede.Domain.Interfaces.Application;
using RabbitMQ.Client;
using Rede.Messaging.Configuration;

namespace Rede.Messaging.Producer;

public class RabbitMQProducer : IMessageProducer
{
    private readonly IModel _channel;
    private readonly string _exchange;
    
    public RabbitMQProducer(IModel channel, IOptions<RabbitMQConfiguration> options)
    {
        _channel = channel;
        _exchange = options.Value.Exchange!;
    }

    public Task SendMessageAsync<T>(T message, CancellationToken cancellationToken)
    {
        var routingKey = EventsMappeing.GetRoutingKey<T>();
        var @event = JsonSerializer.SerializeToUtf8Bytes(message);
        _channel.BasicPublish(
           exchange: _exchange,
           routingKey: routingKey,
           body: @event);
        _channel.WaitForConfirmsOrDie();
        return Task.CompletedTask;
    }
}