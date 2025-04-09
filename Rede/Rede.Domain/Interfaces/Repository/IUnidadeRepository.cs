using Rede.Domain.Entity;
using Rede.Domain.SeedWork;

namespace Rede.Domain.Interfaces.Repository;

public interface IUnidadeRepository
{
    Task AddUnidade(Unidade unidade,CancellationToken cancellationToken);
}