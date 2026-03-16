using Rede.Domain.Entity;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Data.EF.Repository;

public class UnidadeRepository : IUnidadeRepository
{
    private readonly RedeDbContext _context;

    public UnidadeRepository(RedeDbContext context)
    {
        _context = context;
    }

    public Task Editar(Unidade entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task Inserir(Unidade entity, CancellationToken cancellationToken)
    {
        await _context.Set<Unidade>().AddAsync(entity, cancellationToken);
    }

    public Task<Unidade> ObterPorId(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Unidade>> ObterTodos()
    {
        throw new NotImplementedException();
    }

    public Task Remove(Unidade entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}