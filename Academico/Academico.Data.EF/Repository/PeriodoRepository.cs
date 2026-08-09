using System;
using System.Linq.Expressions;
using Academico.Domain.Entity;
using Academico.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace Academico.Data.EF.Repository;

public class PeriodoRepository : IPeriodoRepository
{
    private readonly AcademicoDbContext _context;
    public PeriodoRepository(AcademicoDbContext context)
    {
        _context = context;
    }
    public async Task Cadastrar(Periodo entity, CancellationToken cancellationToken)
    {
        await _context.Set<Periodo>().AddAsync(entity, cancellationToken);
    }

    public Task Delete(Periodo entity, CancellationToken cancellationToken)
    {
        _context.Set<Periodo>().Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<Periodo> Get(Expression<Func<Periodo, bool>> filtro, bool rastrear = true)
    {
        var query = _context.Set<Periodo>();

        if (!rastrear)
            query.AsNoTracking();

        return await query.FirstOrDefaultAsync(filtro);


    }

    public async Task<List<Periodo>> List(Expression<Func<Periodo, bool>> filtro, bool rastrear = true)
    {
        var query = _context.Set<Periodo>();
        
        if(rastrear is false)
            query.AsNoTracking();

        return await query.Where(filtro).ToListAsync();
    }

    public async Task<List<Periodo>> ListAll(DateTime anoInicio, DateTime anoFIm)
    {
        return await _context.Set<Periodo>().Where(p => p.DT_INICIO >= anoInicio && p.DT_FIM <= anoFIm).ToListAsync();
    }

    public async Task<List<Periodo>?> ListByIds(ICollection<int> periodosId)
    {
        return await _context.Set<Periodo>().Where(p => periodosId.Contains(p.Id)).ToListAsync();
    }

    public Task Update(Periodo entity, CancellationToken cancellationToken)
    {
        _context.Set<Periodo>().Update(entity);
        return Task.CompletedTask;
    }
}
