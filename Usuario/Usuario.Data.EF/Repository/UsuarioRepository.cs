using System;
using System.Linq.Expressions;
using Usuario.Domain.Interface.Repository;

namespace Usuario.Data.EF.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    public Task Editar(Domain.Entity.Usuario entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Inserir(Domain.Entity.Usuario entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entity.Usuario> Obter(Expression<Func<Domain.Entity.Usuario, bool>> filtro)
    {
        throw new NotImplementedException();
    }

    public Task<List<Domain.Entity.Usuario>> ObterTodos()
    {
        throw new NotImplementedException();
    }

    public Task Remove(Domain.Entity.Usuario entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
