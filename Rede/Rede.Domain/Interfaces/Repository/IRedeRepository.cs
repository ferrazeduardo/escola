using Rede.Domain.Entity;
using Rede.Domain.SeedWork;

namespace Rede.Domain.Interfaces.Repository;

public interface IRedeRepository : IRepository<Entity.Rede>
{
  Task AddUnidade(Guid id, Unidade unidade);
  Task AddDiaVencimento(Guid redeId, DiaVencimento diaVencimento);
}