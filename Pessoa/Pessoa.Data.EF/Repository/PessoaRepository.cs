using Microsoft.EntityFrameworkCore;
using Pessoa.Application.Interface.Repository;

namespace Pessoa.Data.EF.Repository;

public class PessoaRepository : IPessoaRepository
{
    private readonly PessoaDbContext _dbContext;
    private  DbSet<Domain.SeedWorks.Pessoa> _pessoas => _dbContext.Set<Domain.SeedWorks.Pessoa>();

    public PessoaRepository(PessoaDbContext dbContext)
    {
        _dbContext  = dbContext;
    }
    
    public async Task Inserir(Domain.SeedWorks.Pessoa entity, CancellationToken cancellationToken)
    {
        await _dbContext.Set<Domain.SeedWorks.Pessoa>().AddAsync(entity, cancellationToken);
    }

    public Task Remove(Domain.SeedWorks.Pessoa entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.SeedWorks.Pessoa> ObterPorId(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Domain.SeedWorks.Pessoa>> ObterTodos()
    {
        throw new NotImplementedException();
    }

    public Task Editar(Domain.SeedWorks.Pessoa entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}