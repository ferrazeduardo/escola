using System.Security.AccessControl;
using Moq;
using Rede.Application.UseCases.UnidadeUseCase.AddUnidade;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Test.UnitTest.Application.UseCase.UnidadeUseCase.AddUnidade;

public class AddUnidadeFixture
{


    public AddUnidadeInput ObterAddUnidadeInput()
    {
        var addUnidadeInput = new AddUnidadeInput();
        addUnidadeInput.codigoUsuario = 1;
        addUnidadeInput.numeroUnidade = "249";
        addUnidadeInput.endereco = "endereco teste";
        addUnidadeInput.cep = "66000000";
        addUnidadeInput.complemento = "complemento";
        return addUnidadeInput;
    }
    
    public Mock<IRedeRepository> redeRepositoryMock () => new Mock<IRedeRepository>();
}

[CollectionDefinition(nameof(AddUnidadeFixture))]
public class AddUnidadeTestFixtureCollection : ICollectionFixture<AddUnidadeFixture>{}