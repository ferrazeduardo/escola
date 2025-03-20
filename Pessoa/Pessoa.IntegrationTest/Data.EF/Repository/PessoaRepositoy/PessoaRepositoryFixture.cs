using Bogus.Extensions.Brazil;
using Microsoft.EntityFrameworkCore;
using Pessoa.Data.EF;
using Pessoa.Domain.Entity;
using Pessoa.IntegrationTest.Base;

namespace Pessoa.IntegrationTest.Data.EF.Repository.PessoaRepositoy;

[CollectionDefinition(nameof(PessoaRepositoryFixture))]
public class PessoaRepositoryFixtureCollection
    : ICollectionFixture<PessoaRepositoryFixture>
{
    
}

public class PessoaRepositoryFixture : BaseFixture
{
    public Domain.SeedWorks.Pessoa GetExemploPessoa()
    {
        Pai pai = new Pai( NM_NOME: Faker.Name.FullName(), NR_CPF: Faker.Person.Cpf(),  NR_RG: Faker.Random.Int().ToString(), DS_ENDERECO: Faker.Address.FullAddress(), NR_ENDERECO: Faker.Random.Int().ToString()[..3], UF: Faker.Address.State()[..1],DT_NASCIMENTO: new DateTime(1985,1,1));
        Mae mae = new Mae( NM_NOME: Faker.Name.FullName(), NR_CPF: Faker.Person.Cpf(),  NR_RG: Faker.Random.Int().ToString(), DS_ENDERECO: Faker.Address.FullAddress(), NR_ENDERECO: Faker.Random.Int().ToString()[..3], UF: Faker.Address.State()[..1],DT_NASCIMENTO: new DateTime(1985,1,1));
        Aluno aluno = new Aluno( NM_NOME: Faker.Name.FullName(), NR_CPF: Faker.Person.Cpf(),  NR_RG: Faker.Random.Int().ToString(), DS_ENDERECO: Faker.Address.FullAddress(), NR_ENDERECO: Faker.Random.Int().ToString()[..3], UF: Faker.Address.State()[..1],DT_NASCIMENTO: Faker.Date.Past());
        aluno.AddTelefone(new Telefone( aluno.Id,Faker.Phone.PhoneNumber()));
        aluno.SetMae(mae);
        aluno.SetPai(pai);
        return aluno;
    }

    public PessoaDbContext CreateDbContext()
    {
        return new PessoaDbContext(
            new DbContextOptionsBuilder<PessoaDbContext>()
            .UseInMemoryDatabase("integration-tests-db")
            .Options
            );
    }
}