using Microsoft.Extensions.DependencyInjection;
using Rede.Domain.SeedWork;

namespace Rede.Application;

public class DomainEventPublisher : IDomainEventPublisher
{
    public DomainEventPublisher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    private readonly IServiceProvider _serviceProvider;
    
    public async Task Publish<TDomainEvent>(TDomainEvent domainEvent,CancellationToken cancellationToken )
    where TDomainEvent : DomainEvent
    {
        var handlers = _serviceProvider.GetServices<IDomainEventHandler<TDomainEvent>>();
        if(handlers is null || !handlers.Any())return;
        foreach (var handle in handlers)
        {
            await handle.Handle(domainEvent, cancellationToken);
        }
    }
}