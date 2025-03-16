using Bogus;

namespace Pessoa.IntegrationTest.Base;

public class BaseFixture
{
    protected Faker Faker;

    public BaseFixture()
    {
        Faker = new Faker("pt_BR");
    }
}