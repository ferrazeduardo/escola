namespace Rede.Domain.SeedWork;

public interface IDomainEventPublisher
{
    Task Publish(DomainEvent domainEvent);
}