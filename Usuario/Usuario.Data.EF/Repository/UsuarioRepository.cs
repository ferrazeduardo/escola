using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Usuario.Domain.Entity;
using Usuario.Domain.Interface.Repository;
using Usuario.Domain.Interface.SearchRepository;
using Usuario.Domain.SeedWork;
using AppDomain = Usuario.Domain.Entity;

namespace Usuario.Data.EF.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly UsuarioDbContext _dbContext;
    public UsuarioRepository(UsuarioDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Editar(Domain.Entity.Usuario entity, CancellationToken cancellationToken)
    {
        _dbContext.Set<AppDomain.Usuario>().Update(entity);
    }

    public async Task Inserir(Domain.Entity.Usuario entity, CancellationToken cancellationToken)
    {
        await _dbContext.Set<AppDomain.Usuario>().AddAsync(entity, cancellationToken);
    }

    public async Task<List<AppDomain.Usuario>> Listar(Expression<Func<AppDomain.Usuario, bool>> filtro)
    {
        return await _dbContext.Set<AppDomain.Usuario>().AsNoTracking().Where(filtro)?.ToListAsync();
    }

    public async Task<Domain.Entity.Usuario> Obter(Expression<Func<Domain.Entity.Usuario, bool>> filtro, bool rastrear = true)
    {
        var query = _dbContext.Set<AppDomain.Usuario>()
                        .Include(x => x.redes)
                        .Include(x => x.usuarioRedes)
                        .ThenInclude(x => x.perfilUsuarioRedes)
                        .ThenInclude(ur => ur.Perfil)
                        .AsQueryable();

        if (!rastrear)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(filtro);
    }

    public async Task<List<Domain.Entity.Usuario>> ObterTodos()
    {
        return await _dbContext.Set<AppDomain.Usuario>().ToListAsync();
    }

    public async Task Remove(Domain.Entity.Usuario entity, CancellationToken cancellationToken)
    {
        _dbContext.Set<AppDomain.Usuario>().Remove(entity);
    }

    public async Task<SearchOutput<AppDomain.Usuario>> Search(SearchInput input, CancellationToken cancellationToken)
    {
        var query = _dbContext.Set<AppDomain.Usuario>().AsNoTracking();
        query = input.Order == SearchOrder.Desc ? query.OrderByDescending(x => x.NM_USUARIO) : query.OrderBy(x => x.NM_USUARIO);

        if (!String.IsNullOrEmpty(input.Pesquisa))
            query = query.Where(x => x.NM_USUARIO.Contains(input.Pesquisa));

        var total = await query.CountAsync(cancellationToken);
        var items = await query.Skip((input.Pagina - 1) * input.Quantidade).Take(input.Quantidade).ToListAsync(cancellationToken);
        return new SearchOutput<AppDomain.Usuario>(input.Pagina, input.Quantidade, total, items);

    }
}
