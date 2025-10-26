using System;
using Usuario.Domain.Interface;

namespace Usuario.Data.EF;

public class UnitOfWork : IUnitOfWork
{
    private UsuarioDbContext _usuarioDbContext;

    public UnitOfWork(UsuarioDbContext usuarioDbContext)
    {
        _usuarioDbContext = usuarioDbContext;
    }

    public async Task Commit(CancellationToken cancellationToken)
    {
        await _usuarioDbContext.SaveChangesAsync(cancellationToken);
    }

    public Task RollBack(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
