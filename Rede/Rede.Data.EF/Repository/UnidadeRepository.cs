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
    
    public async Task AddUnidade(Unidade unidade,CancellationToken cancellationToken)
    {
        await _context.Set<Unidade>().AddAsync(unidade,cancellationToken);
    }
}