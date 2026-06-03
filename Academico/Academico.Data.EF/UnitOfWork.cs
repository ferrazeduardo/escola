using System;
using Academico.Domain.Interface;

namespace Academico.Data.EF;

public class UnitOfWork : IUnitOfWork
{
    private AcademicoDbContext _academicoDbContext;

    public UnitOfWork(AcademicoDbContext academicoDbContext)
    {
        _academicoDbContext = academicoDbContext;
    }
    public async Task Commit(CancellationToken cancellationToken)
    {
        await _academicoDbContext.SaveChangesAsync(cancellationToken);
    }
}
