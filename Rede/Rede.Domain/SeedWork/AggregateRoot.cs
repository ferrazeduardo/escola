using System.Collections.ObjectModel;

namespace Rede.Domain.SeedWork;

public abstract class AggregateRoot : Entity
{
    private static readonly List<DomainEvent> _domainEvents = new();

    public IReadOnlyCollection<DomainEvent> Events = _domainEvents.AsReadOnly();
    
    protected AggregateRoot() : base()
    {
        
    }
    
    public void AddDomainEvent(DomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    
    public void RemoveDomainEvent(DomainEvent domainEvent) => _domainEvents.Remove(domainEvent);
    
    public void ClearDomainEvents() => _domainEvents.Clear();
}