namespace Rede.Domain.SeedWork;

public interface IRepository<T>
{
    void Add(T entity);
    void Remove(T entity);
    T FindById(Guid id);
    List<T> GetAll();
}