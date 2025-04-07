using Rede.Domain.Entity;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Data.EF.Repository;

public class RedeRepository : IRedeRepository
{
    public Task Inserir(Domain.Entity.Rede entity)
    {
        throw new NotImplementedException();
    }

    public Task Remove(Domain.Entity.Rede entity)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entity.Rede> ObterPorId(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Domain.Entity.Rede>> ObterTodos()
    {
        throw new NotImplementedException();
    }

    public Task Editar(Domain.Entity.Rede entity)
    {
        throw new NotImplementedException();
    }

    public Task AddUnidade(Guid id, Unidade unidade)
    {
        throw new NotImplementedException();
    }

    public Task AddDiaVencimento(Guid redeId, DiaVencimento diaVencimento)
    {
        throw new NotImplementedException();
    }
}