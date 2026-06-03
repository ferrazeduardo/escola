using System;
using Academico.Domain.Interface;

namespace Academico.Data.EF;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork()
    {
        
    }
    public Task Commit(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
