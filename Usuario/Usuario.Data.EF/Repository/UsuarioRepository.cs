using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Usuario.Domain.Interface.Repository;
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

    public async Task<int> Inserir(Domain.Entity.Usuario entity, CancellationToken cancellationToken)
    {
        await _dbContext.Set<AppDomain.Usuario>().AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<Domain.Entity.Usuario> Obter(Expression<Func<Domain.Entity.Usuario, bool>> filtro)
    {
        return await _dbContext.Set<AppDomain.Usuario>().FindAsync(filtro);
    }

    public async Task<List<Domain.Entity.Usuario>> ObterTodos()
    {
        return await _dbContext.Set<AppDomain.Usuario>().ToListAsync();
    }

    public async Task Remove(Domain.Entity.Usuario entity, CancellationToken cancellationToken)
    {
        _dbContext.Set<AppDomain.Usuario>().Remove(entity);
    }
}
