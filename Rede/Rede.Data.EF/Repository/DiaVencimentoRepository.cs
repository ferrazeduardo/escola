using Rede.Domain.Entity;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Data.EF.Repository;

public class DiaVencimentoRepository : IDiaVencimentoRepository
{
    private readonly RedeDbContext _context;

    public DiaVencimentoRepository(RedeDbContext context)
    {
        _context = context;
    }
    
    public async Task AddDiaVencimento(DiaVencimento dia, CancellationToken cancellationToken)
    {
        await _context.Set<DiaVencimento>().AddAsync(dia, cancellationToken);
    }
}