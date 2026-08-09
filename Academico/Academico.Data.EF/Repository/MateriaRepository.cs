using System;
using System.Linq.Expressions;
using Academico.Domain.Entity;
using Academico.Domain.Interface.Repository;
using Academico.Domain.Interface.SearchRepository;
using Microsoft.EntityFrameworkCore;

namespace Academico.Data.EF.Repository;

public class MateriaRepository : IMateriaRepository
{
    private readonly AcademicoDbContext _context;

    public MateriaRepository(AcademicoDbContext context)
    {
        _context = context;
    }

    public async Task Cadastrar(Materia entity, CancellationToken cancellationToken)
    {
        await _context.Set<Materia>().AddAsync(entity, cancellationToken);
    }

    public Task Delete(Materia entity, CancellationToken cancellationToken)
    {
        _context.Set<Materia>().Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<Materia> Get(Expression<Func<Materia, bool>> filtro, bool rastrear = true)
    {
        return await _context.Set<Materia>().FirstOrDefaultAsync(filtro);
    }

    public async Task<List<Materia>> List(Expression<Func<Materia, bool>> filtro, bool rastrear = true)
    {
        return await
         _context.Set<Materia>().Where(filtro).ToListAsync();
    }

    public async Task<List<Materia>?> ListByIds(ICollection<int> materiasId)
    {
        return await _context.Set<Materia>().Where(m => materiasId.Contains(m.Id)).ToListAsync();
    }

    public async Task<SearchOutput<Materia>> Search(SearchInput input)
    {
        var query = _context.Set<Materia>().AsNoTracking();
        query = input.Ordernacao == SearchOrder.Desc ? query.OrderByDescending(x => x.DS_MATERIA) : query.OrderBy(x => x.DS_MATERIA);

        if (!string.IsNullOrEmpty(input.Pesquisa))
            query = query.Where(x => x.DS_MATERIA.Contains(input.Pesquisa));

        var total = query.Count();
        var items = await query.Skip((input.Pagina - 1) * input.Quantidade).Take(input.Quantidade).ToListAsync();
        return new SearchOutput<Materia>(input.Pagina,input.Quantidade,total,items);
    }

    public Task Update(Materia entity, CancellationToken cancellationToken)
    {
        _context.Set<Materia>().Update(entity);
        return Task.CompletedTask;
    }
}
