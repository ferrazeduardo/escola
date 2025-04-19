namespace Rede.Domain.SeedWork;

public interface IDomainEventHandler<TDomainEvent> where TDomainEvent : DomainEvent
{
    Task Handle(TDomainEvent domainEvent,CancellationToken cancellationToken);
}