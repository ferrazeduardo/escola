using System;
using System.Linq.Expressions;
using Usuario.Domain.Entity;
using Usuario.Domain.Interface.Repository;

namespace Usuario.Data.EF.Repository;

public class UsuarioRedeRepository : IUsuarioRedeRepository
{
    private UsuarioDbContext _usuarioDbContext;

    public UsuarioRedeRepository(UsuarioDbContext usuarioDbContext)
    {
        _usuarioDbContext = usuarioDbContext;
    }
    public Task Editar(UsuarioRede entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task Inserir(UsuarioRede entity, CancellationToken cancellationToken)
    {
        await _usuarioDbContext.Set<UsuarioRede>().AddAsync(entity);
    }

    public Task<List<UsuarioRede>> Listar(Expression<Func<UsuarioRede, bool>> filtro)
    {
        throw new NotImplementedException();
    }

    public Task<UsuarioRede> Obter(Expression<Func<UsuarioRede, bool>> filtro)
    {
        throw new NotImplementedException();
    }

    public Task<List<UsuarioRede>> ObterTodos()
    {
        throw new NotImplementedException();
    }

    public Task Remove(UsuarioRede entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
