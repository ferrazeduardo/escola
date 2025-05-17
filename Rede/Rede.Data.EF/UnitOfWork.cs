using Microsoft.Extensions.Logging;
using Rede.Domain.Interfaces;
using Rede.Domain.SeedWork;

namespace Rede.Data.EF;

public class UnitOfWork : IUnitOfWork
{
    private readonly RedeDbContext _context;
    private readonly IDomainEventPublisher _publisher;
    private readonly ILogger<UnitOfWork> _logger;
    public UnitOfWork(RedeDbContext context,IDomainEventPublisher publisher,ILogger<UnitOfWork> logger)
    {
        _context = context;
        _publisher = publisher;
        _logger = logger;
    }
    
    public async Task Commit(CancellationToken cancellationToken)
    {
        var aggregateRoot = _context.ChangeTracker.Entries<AggregateRoot>()
            .Where(entry => entry.Entity.Events.Any())
            .Select(e => e.Entity);
        
        _logger.LogInformation("Commit: "+aggregateRoot.Count() + " agregados com eventos ");

        var events = aggregateRoot.SelectMany(aggregateRoot => aggregateRoot.Events);
        
        _logger.LogInformation("Commit: "+events.Count() + "eventos ");

        foreach (var @event in events)
            await _publisher.Publish(@event, cancellationToken);
            
        await _context.SaveChangesAsync(cancellationToken);
    }

    public Task Rollback(CancellationToken cancellationToken)
    {
       return Task.CompletedTask;
    }
}
//
// Eventos de domínio e consistência transacional (IDomainEventPublisher) Como UnitOfWork gerencia a persistência das mudanças no banco de dados,
// ele também pode garantir que eventos de domínio sejam disparados após a transação ser concluída com sucesso.
// Isso evita que eventos sejam publicados sem que as mudanças realmente tenham sido persistidas.