using Moq;
using Rede.Application.UseCases.DiaVencimentoUseCase.AddDiaVencimento;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Test.UnitTest.Application.UseCase.DiaVencimentoUseCase.AddDiaVencimento;

public class AddDiaVencimentoFixture
{
    public Mock<IRedeRepository> redeRepositoryMock () => new Mock<IRedeRepository>();
    public Mock<IDiaVencimentoRepository> diaVencimentoRepositoryMock () => new Mock<IDiaVencimentoRepository>();
    
    public AddDiaVencimentoInput ObterAddDiaVencimentoInput()
    {
        var addDiaVencimentoInput = new AddDiaVencimentoInput();
        addDiaVencimentoInput.diaVencimento = new List<int>();
        addDiaVencimentoInput.diaVencimento.Add(1);
        return addDiaVencimentoInput;
    }
}

[CollectionDefinition(nameof(AddDiaVencimentoFixture))]
public class AddUnidadeTestFixtureCollection : ICollectionFixture<AddDiaVencimentoFixture>{}