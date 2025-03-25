using Pessoa.Application.Interface.Repository;
using Pessoa.Domain.Entity;

namespace Pessoa.Data.EF.Repository;

public class RedeRepository : IRedeRepository
{
    public Task Inserir(Rede entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Remove(Rede entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Rede> ObterPorId(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Rede>> ObterTodos()
    {
        throw new NotImplementedException();
    }

    public Task Editar(Rede entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}