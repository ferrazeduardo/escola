using Moq;
using Rede.Application.UseCases.RedeUseCase.Obter;
using Rede.Domain.Entity;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Test.UnitTest.Application.UseCase.RedeUseCase.Obter;

public class ObterTestFixture
{
    public Mock<IRedeRepository> redeRepositoryMock () => new Mock<IRedeRepository>();
    
    public ObterRedeInput ObterRedeInput()
    {
        var obter = new ObterRedeInput();
        obter.id = GetRede().Id;
        return obter;
    }

    public Rede.Domain.Entity.Rede GetRede()
    {
        var rede = new Rede.Domain.Entity.Rede();
        rede.RZ_SOCIAL = "teste razao social";
        rede.NR_CNPJ = "84949144000189";
        rede.AddDiaVencimento(new DiaVencimento(){Dia = 10});
        rede.AddDiaVencimento(new DiaVencimento(){Dia = 20});
        return rede;
    }
}




[CollectionDefinition(nameof(ObterTestFixture))]
public class ObterTestFixtureCollection : ICollectionFixture<ObterTestFixture>
{
    
}