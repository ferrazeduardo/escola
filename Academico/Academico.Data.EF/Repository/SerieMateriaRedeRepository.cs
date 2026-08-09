using System;
using System.Linq.Expressions;
using Academico.Domain.Entity;
using Academico.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace Academico.Data.EF.Repository;

public class SerieMateriaRedeRepository : ISerieMateriaRedeRepository
{
    private readonly AcademicoDbContext _context;

    public SerieMateriaRedeRepository(AcademicoDbContext context)
    {
        _context = context;
    }

    public async Task Cadastrar(SerieMateriaRede entity, CancellationToken cancellationToken)
    {
        await _context.Set<SerieMateriaRede>().AddAsync(entity, cancellationToken);
    }

    public Task Delete(SerieMateriaRede entity, CancellationToken cancellationToken)
    {
        _context.Set<SerieMateriaRede>().Remove(entity);
        return Task.CompletedTask;
    }

    public Task<SerieMateriaRede> Get(Expression<Func<SerieMateriaRede, bool>> filtro, bool rastrear = true)
    {
        var query = _context.Set<SerieMateriaRede>();
        if (rastrear is false) query.AsNoTracking();
        return query.FirstOrDefaultAsync(filtro);
    }

    public Task<List<SerieMateriaRede>> List(Expression<Func<SerieMateriaRede, bool>> filtro, bool rastrear = true)
    {
        var query = _context.Set<SerieMateriaRede>();
        if(rastrear is false) query.AsNoTracking();
        return query.Where(filtro).ToListAsync();
    }

    public Task Update(SerieMateriaRede entity, CancellationToken cancellationToken)
    {
        _context.Set<SerieMateriaRede>().Update(entity);
        return Task.CompletedTask;
    }
}
