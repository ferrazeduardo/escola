using System;
using Rede.Domain.Entity;
using Rede.Domain.SeedWork;

namespace Rede.Domain.Interfaces.Repository;

public interface IRedeUnidadeRepository 
{
    Task Inserir(RedeUnidade entity, CancellationToken cancellationToken);
    void Remover(RedeUnidade entity);
}
