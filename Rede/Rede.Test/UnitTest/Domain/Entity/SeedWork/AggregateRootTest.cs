namespace Rede.Test.UnitTest.Domain.Entity.SeedWork;

public class AggregateRootTest
{
    [Fact(DisplayName = nameof(AddEvent))]
    [Trait("Domain", "AddEvent")]
    public void AddEvent()
    {
        var domainEvent = new DomainEventFake();
        var aggregate = new AggregateRootFake();

        aggregate.AddDomainEvent(domainEvent);

        Assert.True(aggregate.Events.Count == 1);
    }
    
    [Fact(DisplayName = nameof(ClearEvent))]
    [Trait("Domain", "AddEvent")]
    public void ClearEvent()
    {
        var domainEvent = new DomainEventFake();
        var aggregate = new AggregateRootFake();

        aggregate.AddDomainEvent(domainEvent);
        
        aggregate.ClearDomainEvents();

        Assert.True(aggregate.Events.Count == 0);
    }
}