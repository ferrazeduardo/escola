using System;
using Usuario.Domain.Entity;
using Usuario.Domain.Interface.Repository;

namespace Usuario.Data.EF.Repository;

public class PerfilPermissaoRepository : IPerfilPermissaoRepository
{
    private UsuarioDbContext _usuarioDbContext;

    public PerfilPermissaoRepository(UsuarioDbContext usuarioDbContext)
    {
        _usuarioDbContext = usuarioDbContext;
    }

    public async Task Inserir(PerfilPermissao entity, CancellationToken cancellationToken)
    {
        await _usuarioDbContext.Set<PerfilPermissao>().AddAsync(entity, cancellationToken);
    }
}
