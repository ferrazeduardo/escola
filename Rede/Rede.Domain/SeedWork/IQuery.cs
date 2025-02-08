namespace Rede.Domain.SeedWork;

public interface IQuery<T>
{
    T FindById(Guid id);
    List<T> GetAll();
}