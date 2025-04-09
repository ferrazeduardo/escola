using Rede.Domain.Entity;

namespace Rede.Domain.Interfaces.Repository;

public interface IDiaVencimentoRepository
{
    Task AddDiaVencimento(DiaVencimento dia, CancellationToken cancellationToken);
}