namespace Rede.Domain.SeedWork;
// Com essa interface, você pode criar diferentes implementações, como um repositório que utiliza Entity Framework ou outro que utiliza Dapper:
public interface ICommand<T>
{
    void Add(T entity);
    void Remove(T entity);
   
}