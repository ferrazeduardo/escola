using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Usuario.Data.EF.Migrations;
using Usuario.Domain.Entity;
using Usuario.Domain.Interface.Repository;

namespace Usuario.Data.EF.Repository;

public class PerfilUsuarioRedeRepository : IPerilUsuarioRedeRepository
{
    private UsuarioDbContext _usuarioDbContext;

    public PerfilUsuarioRedeRepository(UsuarioDbContext usuarioDbContext)
    {
        _usuarioDbContext = usuarioDbContext;
    }

    public Task Editar(PerfilUsuarioRede entity, CancellationToken cancellationToken)
    {
        _usuarioDbContext.Set<PerfilUsuarioRede>().Update(entity);
        return Task.CompletedTask;
    }

    public async Task Inserir(PerfilUsuarioRede entity, CancellationToken cancellationToken)
    {
        await _usuarioDbContext.Set<PerfilUsuarioRede>().AddAsync(entity, cancellationToken);
    }

    public async Task<List<PerfilUsuarioRede>> Listar(Expression<Func<PerfilUsuarioRede, bool>> filtro, bool rastrear = true)
    {
        var query = _usuarioDbContext.Set<PerfilUsuarioRede>().AsQueryable();

        if (!rastrear)
            query = query.AsNoTracking();

        return await query.Where(filtro).ToListAsync();
    }

    public async Task<PerfilUsuarioRede> Obter(Expression<Func<PerfilUsuarioRede, bool>> filtro, bool rastrear = true)
    {
        var query = _usuarioDbContext.Set<PerfilUsuarioRede>().AsQueryable();

        if (!rastrear)
            query = query.AsNoTracking();

        return await query.Where(filtro).FirstOrDefaultAsync();
    }

    public async Task<List<PerfilUsuarioRede>> ObterTodos()
    {
        return await _usuarioDbContext.Set<PerfilUsuarioRede>().ToListAsync();
    }

    public Task Remove(PerfilUsuarioRede entity, CancellationToken cancellationToken)
    {
        _usuarioDbContext.Set<PerfilUsuarioRede>().Remove(entity);
        return Task.CompletedTask;
    }

    public Task RemoveList(List<PerfilUsuarioRede> entity)
    {
        _usuarioDbContext.Set<PerfilUsuarioRede>().RemoveRange(entity);
        return Task.CompletedTask;
    }
}
