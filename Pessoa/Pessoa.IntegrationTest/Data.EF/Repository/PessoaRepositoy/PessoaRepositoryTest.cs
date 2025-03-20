using Pessoa.Data.EF;
using Pessoa.Data.EF.Repository;
using Pessoa.Domain.Entity;

namespace Pessoa.IntegrationTest.Data.EF.Repository.PessoaRepositoy;

[Collection(nameof(PessoaRepositoryFixture))]
public class PessoaRepositoryTest
{
    public readonly PessoaRepositoryFixture _fixture;

    public PessoaRepositoryTest(PessoaRepositoryFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact(DisplayName = nameof(Insert))]
    public async Task Insert()
    {
        //o contexto
        PessoaDbContext dbContext = _fixture.CreateDbContext();
        //exemplo pessoa
        Domain.SeedWorks.Pessoa pessoa = _fixture.GetExemploPessoa();
        Telefone telefone = pessoa.Telefones.FirstOrDefault();
        //instaciar a classe repository
        var pessoaRepository = new PessoaRepository(dbContext);

        await pessoaRepository.Inserir(pessoa,CancellationToken.None);
        await dbContext.SaveChangesAsync(CancellationToken.None);

        var dbPessoa = await dbContext.Pessoas.FindAsync(pessoa.Id);
        
        Assert.NotNull(dbPessoa);
        Assert.Contains(pessoa.Telefones, t => t.NR_TELEFONE == telefone.NR_TELEFONE);
    }
}