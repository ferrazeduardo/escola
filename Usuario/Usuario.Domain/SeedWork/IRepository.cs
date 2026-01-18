using System.Linq.Expressions;

namespace Usuario.Domain.SeedWork;

public interface IRepository<T>
{
    Task Inserir(T entity, CancellationToken cancellationToken);
    Task Remove(T entity, CancellationToken cancellationToken);
    Task<T> Obter(Expression<Func<T,bool>> filtro);
    Task<List<T>> ObterTodos();
    Task Editar(T entity, CancellationToken cancellationToken);
    Task<List<T>> Listar(Expression<Func<T,bool>> filtro);
}