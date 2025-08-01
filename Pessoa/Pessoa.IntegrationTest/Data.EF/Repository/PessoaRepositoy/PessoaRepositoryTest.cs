using Microsoft.EntityFrameworkCore;
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
        //o contexto
        PessoaDbContext dbContext = _fixture.CreateDbContext();
    }

    [Fact(DisplayName = nameof(Insert))]
    [Trait("Data.EF", "Repository")]
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

    [Fact(DisplayName = nameof(ListPessoas))]
    [Trait("Data.EF ","Repository")]
    public async Task ListPessoas()
    {
        //o contexto
        PessoaDbContext dbContext = _fixture.CreateDbContext();

        var pessoas = _fixture.ListPessoas();
        
        var pessoaRepository = new PessoaRepository(dbContext);
        await dbContext.Rede.AddAsync(pessoas[0].Rede);
        await dbContext.Pessoas.AddAsync(pessoas[0].Pai);
        await dbContext.Pessoas.AddAsync(pessoas[0].Mae);
    
        await dbContext.Pessoas.AddAsync(pessoas[0]);
        
        await dbContext.Pessoas.AddAsync(pessoas[1].Pai);
        await dbContext.Pessoas.AddAsync(pessoas[1].Mae);
    
        await dbContext.Pessoas.AddAsync(pessoas[1]);
        await dbContext.SaveChangesAsync(CancellationToken.None);

        var pessoasDb = await pessoaRepository.ObterTodos();
        
        Assert.NotNull(pessoasDb);
        Assert.True(pessoasDb.Count > 0);
    }

    [Fact(DisplayName = nameof(ObterPessoa))]
    [Trait("Data.EF ","Repository")]
    public async Task ObterPessoa()
    {
        //o contexto
        PessoaDbContext dbContext = _fixture.CreateDbContext();
        
        Domain.SeedWorks.Pessoa pessoa = _fixture.GetExemploPessoa();
        var pessoaRepository = new PessoaRepository(dbContext);
        
        await dbContext.Pessoas.AddAsync(pessoa);
        await dbContext.SaveChangesAsync(CancellationToken.None);
        
        var pessoaDb = await pessoaRepository.ObterPorId(pessoa.Id);
        
        Assert.Equal(pessoa.Id, pessoaDb.Id);
    }

    [Fact(DisplayName = nameof(RemovePessoa))]
    [Trait("Data.EF", "Repository")]
    public async Task RemovePessoa()
    {
        PessoaDbContext dbContext = _fixture.CreateDbContext();
        Domain.SeedWorks.Pessoa pessoa = _fixture.GetExemploPessoa();
        
        var pessoaRepository = new PessoaRepository(dbContext);
        
        await dbContext.Pessoas.AddAsync(pessoa);
        await dbContext.SaveChangesAsync(CancellationToken.None);


        await pessoaRepository.Remove(pessoa, CancellationToken.None);
        await dbContext.SaveChangesAsync(CancellationToken.None);

        var dbPessoa = await dbContext.Pessoas.FindAsync(pessoa.Id);
        
        Assert.Null(dbPessoa);
    }

    [Fact(DisplayName = nameof(EditarPessoa))]
    [Trait("Data.EF", "Repository")]
    public async Task EditarPessoa()
    {
        PessoaDbContext dbContext = _fixture.CreateDbContext();
        Domain.SeedWorks.Pessoa pessoa = _fixture.GetExemploPessoa();
        Domain.SeedWorks.Pessoa pessoaUpdate = _fixture.GetExemploPessoaUpdate(pessoa);
        
        var pessoaRepository = new PessoaRepository(dbContext);
        
        await dbContext.Pessoas.AddAsync(pessoa);
        await dbContext.SaveChangesAsync(CancellationToken.None);
        
        await pessoaRepository.Editar(pessoaUpdate, CancellationToken.None);
        await dbContext.SaveChangesAsync(CancellationToken.None);

        var dbPessoa = await dbContext.Pessoas.FindAsync(pessoa.Id);
        
        Assert.Equal(pessoaUpdate.NM_NOME,dbPessoa.NM_NOME);
        Assert.Equal(pessoaUpdate.DT_NASCIMENTO.Date,dbPessoa.DT_NASCIMENTO.Date);
    }

    
    [Fact(DisplayName = nameof(ObterPeloCpf_DeveRetornarPessoa))]
    [Trait("Data.EF", "Repository")]
    public async Task ObterPeloCpf_DeveRetornarPessoa()
    {
        var dbContext = _fixture.CreateDbContext();
        Domain.SeedWorks.Pessoa exemploPessoa = _fixture.GetExemploPessoa();
        var pessoaRepository = new PessoaRepository(dbContext);
        
        await dbContext.Rede.AddAsync(exemploPessoa.Rede);
        await dbContext.Pessoas.AddAsync(exemploPessoa.Pai);
        await dbContext.Pessoas.AddAsync(exemploPessoa.Mae);
        await dbContext.Pessoas.AddAsync(exemploPessoa);
        await dbContext.SaveChangesAsync(CancellationToken.None);

        var pessoaDbDirect = await pessoaRepository.ObterPeloCpf(exemploPessoa.NR_CPF, exemploPessoa.ID_REDE);

        Assert.NotNull(pessoaDbDirect);
        Assert.Equal(exemploPessoa.Id, pessoaDbDirect.Id);
        Assert.Equal(exemploPessoa.NM_NOME, pessoaDbDirect.NM_NOME);
        Assert.Equal(exemploPessoa.NR_CPF, pessoaDbDirect.NR_CPF);
    }

}