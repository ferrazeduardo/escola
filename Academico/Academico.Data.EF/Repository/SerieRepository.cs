using System;
using System.Linq.Expressions;
using Academico.Domain.Entity;
using Academico.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace Academico.Data.EF.Repository;

public class SerieRepository : ISerieRepository
{
    private readonly AcademicoDbContext _context;

    public SerieRepository(AcademicoDbContext context)
    {
        _context = context;
    }
    public async Task Cadastrar(Serie entity, CancellationToken cancellationToken)
    {
        await _context.Set<Serie>().AddAsync(entity, cancellationToken);
    }

    public Task Delete(Serie entity, CancellationToken cancellationToken)
    {
        _context.Set<Serie>().Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<Serie> Get(Expression<Func<Serie, bool>> filtro, bool rastrear = true)
    {
        var query = _context.Set<Serie>();

        if (rastrear is false)
            query.AsNoTracking();

        return await query.FirstOrDefaultAsync(filtro);
    }

    public Task<List<Serie>> List(Expression<Func<Serie, bool>> filtro, bool rastrear = true)
    {
        var query = _context.Set<Serie>();

        if (rastrear is false)
            query.AsNoTracking();

        return query.Where(filtro).ToListAsync();
    }

    public Task Update(Serie entity, CancellationToken cancellationToken)
    {
        _context.Set<Serie>().Update(entity);
        return Task.CompletedTask;
    }
}
