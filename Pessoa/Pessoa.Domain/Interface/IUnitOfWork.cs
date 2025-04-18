namespace Pessoa.Domain.Interface;

public interface IUnitOfWork
{
     Task Commit(CancellationToken cancellationToken);
     Task Rollback(CancellationToken cancellationToken);
}