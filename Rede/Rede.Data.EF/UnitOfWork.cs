using Rede.Domain.Interfaces;

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
        throw new NotImplementedException();
    }
}