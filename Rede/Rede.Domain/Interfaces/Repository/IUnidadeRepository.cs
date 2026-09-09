using Rede.Domain.Entity;
using Rede.Domain.SeedWork;

namespace Rede.Domain.Interfaces.Repository;

public interface IUnidadeRepository : IRepository<Unidade>
{
    Task<List<Unidade>> ListarTodosPorRede(int id_rede);
}