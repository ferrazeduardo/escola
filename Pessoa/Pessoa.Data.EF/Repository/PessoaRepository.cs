using Pessoa.Application.Interface.Repository;

namespace Pessoa.Data.EF.Repository;

public class PessoaRepository : IPessoaRepository
{
    public Task Inserir(Domain.SeedWorks.Pessoa entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Remove(Domain.SeedWorks.Pessoa entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.SeedWorks.Pessoa> ObterPorId(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Domain.SeedWorks.Pessoa>> ObterTodos()
    {
        throw new NotImplementedException();
    }

    public Task Editar(Domain.SeedWorks.Pessoa entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}