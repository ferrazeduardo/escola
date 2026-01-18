using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Usuario.Domain.Interface.Repository;
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
        try
        {

            return await _dbContext.Set<AppDomain.Usuario>().Where(filtro)?.ToListAsync();
        }
        catch (Exception e)
        {

        }

        return null;
    }

    public async Task<Domain.Entity.Usuario> Obter(Expression<Func<Domain.Entity.Usuario, bool>> filtro)
    {
        return await _dbContext.Set<AppDomain.Usuario>().FirstOrDefaultAsync(filtro);
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
