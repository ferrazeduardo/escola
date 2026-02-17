namespace Rede.Domain.SeedWork;

public interface IRepository<T>
{
    Task Inserir(T entity, CancellationToken cancellationToken);
    Task Remove(T entity, CancellationToken cancellationToken);
    Task<T> ObterPorId(int id);
    Task<List<T>> ObterTodos();
    Task Editar(T entity, CancellationToken cancellationToken);
}