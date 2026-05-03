using Microsoft.EntityFrameworkCore;
using Rede.Domain.Entity;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Data.EF.Repository;

public class RedeRepository : IRedeRepository
{
    private readonly RedeDbContext _context;


    public RedeRepository(RedeDbContext context)
    {
        _context = context;
    }

    public async Task Inserir(Domain.Entity.Rede entity, CancellationToken cancellationToken)
    {
        await _context.Set<Domain.Entity.Rede>().AddAsync(entity, cancellationToken);
    }

    public async Task Remove(Domain.Entity.Rede entity, CancellationToken cancellationToken)
    {
        _context.Rede.Remove(entity);
    }

    public async Task<Domain.Entity.Rede> ObterPorId(int id, bool rastreavel = false)
    {
        var redeQuery = _context.Set<Domain.Entity.Rede>().Include(x => x.Unidades).ThenInclude(u => u.Salas).AsQueryable();

        if (rastreavel)
            redeQuery = redeQuery.AsNoTracking();

        var rede = await redeQuery.FirstOrDefaultAsync(rede => rede.Id == id);
        return rede;
    }

    public async Task<List<Domain.Entity.Rede>> ObterTodos()
    {
        var redes = await _context.Set<Domain.Entity.Rede>().AsNoTracking().ToListAsync();
        return redes;
    }

    public Task Editar(Domain.Entity.Rede entity, CancellationToken cancellationToken)
    {
        _context.Set<Domain.Entity.Rede>().Update(entity);
        return Task.CompletedTask;
    }


}