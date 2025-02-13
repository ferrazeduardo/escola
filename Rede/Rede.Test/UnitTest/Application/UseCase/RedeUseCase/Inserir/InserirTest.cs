using Moq;
using Rede.Application.UseCases.RedeUseCase.Inserir;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Test.UnitTest.Application.UseCase.RedeUseCase.Inserir;

[Collection(nameof(InserirTestFixture))]
public class InserirTest
{
    private readonly InserirTestFixture _fixture;
    private readonly Mock<IRedeRepository> _redeRepositoryMock;

    public InserirTest(InserirTestFixture fixture)
    {
        _fixture = fixture;
        _redeRepositoryMock = _fixture.redeRepositoryMock();
    }

    [Fact(DisplayName = nameof(Inserir))]
    [Trait("Application", "UseCase - RedeUseCase - Inserir")]
    public async Task Inserir()
    {
        var rede = It.IsAny<Rede.Domain.Entity.Rede>();
        var inserir = _fixture.ObterInserirRedeCommand();
        _redeRepositoryMock.Setup(m => m.Inserir(rede)).Returns(Task.CompletedTask);

        var response = new InserirRede(_redeRepositoryMock.Object);
        var output = await response.Handle(inserir,CancellationToken.None);
        // Assert
        Assert.NotNull(output);
        Assert.NotEqual(Guid.Empty, output.codigo);
    }
}