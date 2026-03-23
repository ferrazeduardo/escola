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
        if (entity.Unidades.Count > 0)
        {
            await _context.Set<Unidade>().AddRangeAsync(entity.Unidades, cancellationToken);
            ICollection<Telefone> Telefones = entity.Unidades.SelectMany(u => u.Telefones).ToList();
            await _context.Set<Telefone>().AddRangeAsync(Telefones, cancellationToken);
        }

        if (entity.DiaVencimentos.Count > 0)
        {
            await _context.Set<DiaVencimento>().AddRangeAsync(entity.DiaVencimentos, cancellationToken);
        }
    }

    public async Task Remove(Domain.Entity.Rede entity, CancellationToken cancellationToken)
    {
         _context.Rede.Remove(entity);
    }

    public async Task<Domain.Entity.Rede> ObterPorId(int id, bool rastreavel = false)
    {
        var redeQuery =  _context.Set<Domain.Entity.Rede>().Include(x => x.Unidades).AsQueryable();

        if(rastreavel)
            redeQuery = redeQuery.AsNoTracking();

        var rede = await redeQuery.FirstOrDefaultAsync(rede => rede.Id == id);
        return rede;
    }

    public async Task<List<Domain.Entity.Rede>> ObterTodos()
    {
        var redes = await _context.Set<Domain.Entity.Rede>().AsNoTracking().ToListAsync();
        return redes;
    }

    public async Task Editar(Domain.Entity.Rede entity, CancellationToken cancellationToken)
    {
        _context.Set<Domain.Entity.Rede>().Update(entity);
    }

   
}