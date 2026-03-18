using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Usuario.Domain.Entity;
using Usuario.Domain.Interface.Repository;
using AppDomain = Usuario.Domain.Entity;

namespace Usuario.Data.EF.Repository;

public class RedeRepository : IRedeRepository
{
    private UsuarioDbContext _usuarioDbContext;

    public RedeRepository(UsuarioDbContext usuarioDbContext)
    {
        _usuarioDbContext = usuarioDbContext;
    }

    public Task Editar(Rede entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task Inserir(Rede entity, CancellationToken cancellationToken)
    {
        var redeJaExiste = await _usuarioDbContext.Set<AppDomain.Rede>().FirstOrDefaultAsync(x => x.Id == entity.Id);

        if (redeJaExiste is null)
        {
            await _usuarioDbContext.Set<AppDomain.Rede>().AddAsync(entity);
        }
    }

    public Task<List<Rede>> Listar(Expression<Func<Rede, bool>> filtro)
    {
        throw new NotImplementedException();
    }

    public Task<Rede> Obter(Expression<Func<Rede, bool>> filtro, bool rastrear = true)
    {
        throw new NotImplementedException();
    }

    public Task<List<Rede>> ObterTodos()
    {
        throw new NotImplementedException();
    }

    public Task Remove(Rede entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
