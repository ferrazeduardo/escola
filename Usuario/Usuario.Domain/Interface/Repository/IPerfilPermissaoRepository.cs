using System;
using Usuario.Domain.Entity;
using Usuario.Domain.SeedWork;

namespace Usuario.Domain.Interface.Repository;

public interface IPerfilPermissaoRepository 
{
    Task Inserir(PerfilPermissao entity, CancellationToken cancellationToken);
}
