using System;

namespace Academico.Domain.Interface;

public interface IUnitOfWork
{
    Task Commit(CancellationToken cancellationToken);
    Task BeginTransaction(CancellationToken cancellationToken);
    Task CommitTransaction(CancellationToken cancellationToken);
    Task RollbackTransaction(CancellationToken cancellationToken);
}
