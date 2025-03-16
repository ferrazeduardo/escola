using Pessoa.IntegrationTest.Base;

namespace Pessoa.IntegrationTest.Data.EF.Repository.PessoaRepositoy;

[CollectionDefinition(nameof(PessoaRepositoryFixture))]
public class PessoaRepositoryFixtureCollection
    : ICollectionFixture<PessoaRepositoryFixture>
{
    
}

public class PessoaRepositoryFixture : BaseFixture
{
    
}