using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Rede.Application.EventHandlers;
using Rede.Domain.Events;
using Rede.Domain.SeedWork;

namespace Rede.Application.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddDomainEvents();
        return services;
    }
    
    private static IServiceCollection AddDomainEvents(
        this IServiceCollection services)
    {
        services.AddTransient<IDomainEventPublisher, DomainEventPublisher>();
        services.AddTransient<IDomainEventHandler<RedeSalvarEvent>,
            SendNovaRedeEventHandler>();

        return services;
    }
}