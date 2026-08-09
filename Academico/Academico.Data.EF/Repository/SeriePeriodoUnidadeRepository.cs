using System;
using System.Linq.Expressions;
using Academico.Domain.Entity;
using Academico.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace Academico.Data.EF.Repository;

public class SeriePeriodoUnidadeRepository : ISeriePeriodoUnidadeRepository
{
    private readonly AcademicoDbContext _context;

    public SeriePeriodoUnidadeRepository(AcademicoDbContext context)
    {
        _context = context;
    }
    public async Task Cadastrar(SeriePeriodoUnidade entity, CancellationToken cancellationToken)
    {
        await _context.Set<SeriePeriodoUnidade>().AddAsync(entity, cancellationToken);
    }

    public Task Delete(SeriePeriodoUnidade entity, CancellationToken cancellationToken)
    {
        _context.Set<SeriePeriodoUnidade>().Remove(entity);
        return Task.CompletedTask;
    }

    public Task<SeriePeriodoUnidade> Get(Expression<Func<SeriePeriodoUnidade, bool>> filtro, bool rastrear = true)
    {
        var query = _context.Set<SeriePeriodoUnidade>();
        if(rastrear is false) query.AsNoTracking();
        return query.FirstOrDefaultAsync(filtro);
    }

    public Task<List<SeriePeriodoUnidade>> List(Expression<Func<SeriePeriodoUnidade, bool>> filtro, bool rastrear = true)
    {
        var query = _context.Set<SeriePeriodoUnidade>();
        if(rastrear is false) query.AsNoTracking();
        return query.Where(filtro).ToListAsync();
    }

    public Task Update(SeriePeriodoUnidade entity, CancellationToken cancellationToken)
    {
             _context.Set<SeriePeriodoUnidade>().Update(entity);
        return Task.CompletedTask;
    }
}
