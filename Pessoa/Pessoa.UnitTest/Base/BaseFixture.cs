using Bogus;
using Moq;
using Pessoa.Application.Interface.Repository;
using Pessoa.Domain.Interface;

namespace Pessoa.UnitTest.Base;

public class BaseFixture
{
    protected Faker Faker;
    
    public Mock<IPessoaRepository> GetRepositoryMock()
        => new();

    public Mock<IRedeRepository> GetRedeRepositoryMock()
        => new();

    public Mock<IUnitOfWork> GetUnitOfWorkMock()
        => new();
    
    public BaseFixture()
    {
        Faker = new Faker("pt_BR");
    }
}