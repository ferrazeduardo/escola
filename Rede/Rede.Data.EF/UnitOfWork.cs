using Microsoft.Extensions.Logging;
using Rede.Domain.Interfaces;
using Rede.Domain.SeedWork;

namespace Rede.Data.EF;

public class UnitOfWork : IUnitOfWork
{
    private readonly RedeDbContext _context;
    public UnitOfWork(RedeDbContext context)
    {
        _context = context;
    }
    
    public async Task Commit(CancellationToken cancellationToken)
    {
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