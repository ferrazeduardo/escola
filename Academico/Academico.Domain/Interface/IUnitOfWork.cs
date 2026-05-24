using System;

namespace Academico.Domain.Interface;

public interface IUnitOfWork
{
    Task Commit(CancellationToken cancellationToken);
}
