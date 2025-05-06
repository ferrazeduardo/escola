using Rede.Domain.Events;
using Rede.Domain.Interfaces.Application;
using Rede.Domain.SeedWork;

namespace Rede.Application.EventHandlers;

public class SendNovaRedeEventHandler : IDomainEventHandler<RedeSalvarEvent>
{
    private readonly IMessageProducer _messageProducer;

    public SendNovaRedeEventHandler(IMessageProducer messageProducer)
    {
        _messageProducer = messageProducer;
    }

    public async Task Handle(RedeSalvarEvent domainEvent, CancellationToken cancellationToken)
    {
        await _messageProducer.SendMessageAsync(domainEvent, cancellationToken);
    }
}