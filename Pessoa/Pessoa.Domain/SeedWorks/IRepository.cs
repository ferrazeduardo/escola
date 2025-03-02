namespace Pessoa.Domain.SeedWorks;

public interface IRepository<T>
{
    Task Inserir(T entity);
    Task Remove(T entity);
    Task<T> ObterPorId(Guid id);
    Task<List<T>> ObterTodos();
    Task Editar(T entity);
}