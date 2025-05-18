using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using Rede.Domain.Events;
using Rede.Messaging.Configuration;
using Rede.Messaging.Producer;

namespace Rede.Test.UnitTest;

public class RabbitMQProducerTest
{
    [Fact(DisplayName = nameof(SendMessageAsyncTest))]
    [Trait("Messaging", "Producer")]
    public async Task SendMessageAsyncTest()
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost",
            UserName = "user",
            Password = "password"
        };
        
         var connection = factory.CreateConnection();
         var channel = connection.CreateModel();
        channel.ConfirmSelect();
        var options = Options.Create(new RabbitMQConfiguration
        {
            Exchange = "rede.events",
            
        });
        var produtor = new RabbitMQProducer(channel,options);

        var @event = new RedeSalvarEvent( "teste razao social",new Guid());
        produtor.SendMessageAsync<RedeSalvarEvent>(@event,CancellationToken.None);
    }
}