using System;
using System.Linq.Expressions;
using Usuario.Domain.Entity;
using Usuario.Domain.Interface.Repository;
using AppDomain = Usuario.Domain.Entity;
namespace Usuario.Data.EF.Repository;

public class PerfilRepository : IPerfilRepository
{
    private UsuarioDbContext _usuarioDbContext;

    public PerfilRepository(UsuarioDbContext usuarioDbContext)
    {
        _usuarioDbContext = usuarioDbContext;
    }
    public Task Editar(Perfil entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task Inserir(Perfil entity, CancellationToken cancellationToken)
    {
        await _usuarioDbContext.Set<AppDomain.Perfil>().AddAsync(entity,cancellationToken);
    }

    public Task<List<Perfil>> Listar(Expression<Func<Perfil, bool>> filtro)
    {
        throw new NotImplementedException();
    }

    public Task<Perfil> Obter(Expression<Func<Perfil, bool>> filtro, bool rastrear = true)
    {
        throw new NotImplementedException();
    }

    public Task<List<Perfil>> ObterTodos()
    {
        throw new NotImplementedException();
    }

    public Task Remove(Perfil entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
