using Rede.Domain.SeedWork;

namespace Rede.Domain.Interfaces.Application;

public interface IMessageProducer
{
    Task SendMessageAsync<T>(T message,CancellationToken cancellationToken);
}