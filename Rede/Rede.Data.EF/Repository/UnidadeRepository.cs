using Microsoft.EntityFrameworkCore;
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
        _context.Set<Unidade>().Update(entity);
        return Task.CompletedTask;
    }

    public async Task Inserir(Unidade entity, CancellationToken cancellationToken)
    {
        await _context.Set<Unidade>().AddAsync(entity, cancellationToken);
    }

    public Task<Unidade> ObterPorId(int id, bool rastreavel = false)
    {
        var query = _context.Set<Unidade>().AsQueryable();

        if (!rastreavel)
            query = query.AsNoTracking();

        return query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<List<Unidade>> ObterTodos()
    {
        return _context.Set<Unidade>().ToListAsync();
    }

    public Task Remove(Unidade entity, CancellationToken cancellationToken)
    {
        _context.Set<Unidade>().Remove(entity);
        return Task.CompletedTask;
    }
}