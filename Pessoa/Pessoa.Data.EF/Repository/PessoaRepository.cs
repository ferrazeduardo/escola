using Microsoft.EntityFrameworkCore;
using Pessoa.Application.Interface.Repository;
using Pessoa.Domain.Entity;

namespace Pessoa.Data.EF.Repository;

public class PessoaRepository : IPessoaRepository
{
    private readonly PessoaDbContext _dbContext;
    private  DbSet<Telefone> _telefone => _dbContext.Set<Telefone>();

    public PessoaRepository(PessoaDbContext dbContext)
    {
        _dbContext  = dbContext;
    }
    
    public async Task Inserir(Domain.SeedWorks.Pessoa entity, CancellationToken cancellationToken)
    {
        await _dbContext.Set<Domain.SeedWorks.Pessoa>().AddAsync(entity, cancellationToken);

        if (entity.Telefones.Count > 0)
        {
            await _telefone.AddRangeAsync(entity.Telefones, cancellationToken);
        }
    }

    public async  Task Remove(Domain.SeedWorks.Pessoa entity, CancellationToken cancellationToken)
    {
         _dbContext.Set<Domain.SeedWorks.Pessoa>().Remove(entity);
         await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Domain.SeedWorks.Pessoa> ObterPorId(Guid id)
    {
        var pessoa = await _dbContext.Set<Domain.SeedWorks.Pessoa>().FindAsync(id);
        return pessoa;
    }

    public async Task<Domain.SeedWorks.Pessoa> ObterPeloCpf(string cpf, Guid id_rede)
    {
        var pessoa = await _dbContext.Set<Domain.SeedWorks.Pessoa>().FirstOrDefaultAsync(p => p.NR_CPF == cpf && p.ID_REDE == id_rede);
        return pessoa;
    }

    public  async Task<List<Domain.SeedWorks.Pessoa>> ObterTodos()
    {
        var pessoas = await _dbContext.Set<Domain.SeedWorks.Pessoa>()
            .ToListAsync();

        return pessoas;
    }

    public async  Task Editar(Domain.SeedWorks.Pessoa entity, CancellationToken cancellationToken)
    {
         _dbContext.Set<Domain.SeedWorks.Pessoa>().Update(entity);
         await _dbContext.SaveChangesAsync(cancellationToken);
    }

}