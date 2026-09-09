using System;
using Rede.Domain.Entity;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Data.EF.Repository;

public class RedeUnidadeRepository : IRedeUnidadeRepository
{
    private RedeDbContext _redeDbContext;

    public RedeUnidadeRepository(RedeDbContext redeDbContext)
    {
        _redeDbContext = redeDbContext;
    }

    public async Task Inserir(RedeUnidade entity, CancellationToken cancellationToken)
    {
        await _redeDbContext.Set<RedeUnidade>().AddAsync(entity, cancellationToken);
    }

    public void Remover(RedeUnidade entity)
    {
        _redeDbContext.Set<RedeUnidade>().Remove(entity);
    }
}
