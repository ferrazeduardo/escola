using System;
using System.Linq.Expressions;
using Academico.Domain.Entity;
using Academico.Domain.Interface.Repository;
using Academico.Domain.Interface.SearchRepository;
using Microsoft.EntityFrameworkCore;

namespace Academico.Data.EF.Repository;

public class PessoaRepository : IPessoaRepository
{
    private readonly AcademicoDbContext _context;

    public PessoaRepository(AcademicoDbContext context)
    {
        _context = context;
    }
    public async Task Cadastrar(Pessoa entity, CancellationToken cancellationToken)
    {
        await _context.Set<Pessoa>().AddAsync(entity, cancellationToken); ;
    }

    public Task Delete(Pessoa entity, CancellationToken cancellationToken)
    {
        _context.Set<Pessoa>().Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<Pessoa> Get(Expression<Func<Pessoa, bool>> filtro, bool rastrear = true)
    {
        var query = _context.Set<Pessoa>().AsQueryable();

        if (!rastrear)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(filtro);

    }

    public async Task<List<Pessoa>> List(Expression<Func<Pessoa, bool>> filtro, bool rastrear = true)
    {
        var query = _context.Set<Pessoa>().AsQueryable();

        if (!rastrear)
            query = query.AsNoTracking();

        return await query.Where(filtro).ToListAsync();
    }

    public async Task<SearchOutput<Pessoa>> Search(SearchInput input)
    {
        var query = _context.Set<Pessoa>().AsNoTracking();
        query = input.Ordernacao == SearchOrder.Desc ? query.OrderByDescending(x => x.Nome) : query.OrderBy(x => x.Nome);

        if (!string.IsNullOrEmpty(input.Pesquisa))
            query = query.Where(x => x.Nome.Contains(input.Pesquisa));

        var total = query.Count();
        var items = await query.Skip((input.Pagina - 1) * input.Quantidade).Take(input.Quantidade).ToListAsync();
        return new SearchOutput<Pessoa>(input.Pagina, input.Quantidade, total, items);
    }

    public Task Update(Pessoa entity, CancellationToken cancellationToken)
    {
        _context.Set<Pessoa>().Update(entity);
        return Task.CompletedTask;
    }
}
