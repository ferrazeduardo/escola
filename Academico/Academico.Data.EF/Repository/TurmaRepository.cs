using System;
using System.Linq.Expressions;
using Academico.Domain.Entity;
using Academico.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace Academico.Data.EF.Repository;

public class TurmaRepository : ITurmaRepository
{
    private readonly AcademicoDbContext _context;

    public TurmaRepository(AcademicoDbContext context)
    {
        _context = context;
    }

    public async Task Cadastrar(Turma entity, CancellationToken cancellationToken)
    {
        await _context.Set<Turma>().AddAsync(entity, cancellationToken);
    }

    public Task Delete(Turma entity, CancellationToken cancellationToken)
    {
        _context.Set<Turma>().Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<Turma> Get(Expression<Func<Turma, bool>> filtro, bool rastrear = true)
    {
        var query = _context.Set<Turma>().AsQueryable();

        if (!rastrear)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(filtro);
    }

    public async Task<Turma> GetComLock(int id, CancellationToken cancellationToken)
    {
        return await _context.Set<Turma>()
            .FromSqlInterpolated($"SELECT * FROM \"Turma\" WHERE \"Id\" = {id} FOR UPDATE")
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<Turma>> List(Expression<Func<Turma, bool>> filtro, bool rastrear = true)
    {
        var query = _context.Set<Turma>().AsQueryable();

        if (!rastrear)
            query = query.AsNoTracking();

        return await query.Where(filtro).ToListAsync();
    }

    public Task Update(Turma entity, CancellationToken cancellationToken)
    {
        _context.Set<Turma>().Update(entity);
        return Task.CompletedTask;
    }
}
