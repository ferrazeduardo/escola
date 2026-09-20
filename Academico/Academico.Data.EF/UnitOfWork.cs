using System;
using Academico.Domain.Interface;
using Microsoft.EntityFrameworkCore.Storage;

namespace Academico.Data.EF;

public class UnitOfWork : IUnitOfWork
{
    private AcademicoDbContext _academicoDbContext;
    private IDbContextTransaction _transaction;

    public UnitOfWork(AcademicoDbContext academicoDbContext)
    {
        _academicoDbContext = academicoDbContext;
    }
    public async Task Commit(CancellationToken cancellationToken)
    {
        await _academicoDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task BeginTransaction(CancellationToken cancellationToken)
    {
        _transaction = await _academicoDbContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransaction(CancellationToken cancellationToken)
    {
        if (_transaction is null)
            return;

        await _transaction.CommitAsync(cancellationToken);
        await _transaction.DisposeAsync();
        _transaction = null;
    }

    public async Task RollbackTransaction(CancellationToken cancellationToken)
    {
        if (_transaction is null)
            return;

        await _transaction.RollbackAsync(cancellationToken);
        await _transaction.DisposeAsync();
        _transaction = null;
    }
}
