using Pessoa.Domain.Interface;

namespace Pessoa.Data.EF;

public class UnitOfWork : IUnitOfWork
{
    private readonly PessoaDbContext _context;

    public UnitOfWork(PessoaDbContext context)
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