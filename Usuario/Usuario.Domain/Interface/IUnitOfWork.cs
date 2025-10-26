using System;

namespace Usuario.Domain.Interface;

public interface IUnitOfWork
{
    Task Commit(CancellationToken cancellationToken);
    Task RollBack(CancellationToken cancellationToken);
}
