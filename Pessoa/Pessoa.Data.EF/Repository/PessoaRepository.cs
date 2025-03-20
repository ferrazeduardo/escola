using Microsoft.EntityFrameworkCore;
using Pessoa.Application.Interface.Repository;
using Pessoa.Domain.Entity;

namespace Pessoa.Data.EF.Repository;

public class PessoaRepository : IPessoaRepository
{
    private readonly PessoaDbContext _dbContext;
    private  DbSet<Domain.SeedWorks.Pessoa> _pessoas => _dbContext.Set<Domain.SeedWorks.Pessoa>();
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

    public Task Remove(Domain.SeedWorks.Pessoa entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.SeedWorks.Pessoa> ObterPorId(Guid id)
    {
        throw new NotImplementedException();
    }

    public  async Task<List<Domain.SeedWorks.Pessoa>> ObterTodos()
    {
        var pessoas = await _dbContext.Pessoas
            .Include(p => p.Mae)
            .Include(p => p.Pai)
            .ToListAsync();

        return pessoas;
    }

    public Task Editar(Domain.SeedWorks.Pessoa entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task InserirAluno(Aluno aluno, CancellationToken cancellationToken)
    {
       await Inserir(aluno.Pai,cancellationToken);
       
       await Inserir(aluno.Mae, cancellationToken);
       
       await Inserir(aluno,cancellationToken);
       ;
    }
}