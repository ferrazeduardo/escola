namespace Rede.Domain.SeedWork;

public interface IDomainEventPublisher
{
    Task Publish<TDomainEvent>(TDomainEvent domainEvent, CancellationToken cancellationToken)
        where TDomainEvent : DomainEvent;
}