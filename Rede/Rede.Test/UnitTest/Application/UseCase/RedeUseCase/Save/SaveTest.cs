using Moq;
using Rede.Application.UseCases.RedeUseCase.Save;
using Rede.Domain.Interfaces;
using Rede.Domain.Interfaces.Repository;
using Rede.Test.UnitTest.Application.UseCase.RedeUseCase.Inserir;

namespace Rede.Test.UnitTest.Application.UseCase.RedeUseCase.Save;

[Collection(nameof(SaveTestFixture))]
public class SaveTest
{
    private readonly SaveTestFixture _fixture;
    private readonly Mock<IRedeRepository> _redeRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;

    public SaveTest(SaveTestFixture fixture)
    {
        _fixture = fixture;
        _redeRepositoryMock = _fixture.redeRepositoryMock();
        _unitOfWorkMock = _fixture.unitOfWorkMock();
    }

    [Fact(DisplayName = nameof(Inserir))]
    [Trait("Application", "UseCase - RedeUseCase - Inserir")]
    public async Task Inserir()
    {
        var rede = It.IsAny<Rede.Domain.Entity.Rede>();
        var inserir = _fixture.ObterInserirRedeCommand();
        _redeRepositoryMock.Setup(m => m.Inserir(rede,CancellationToken.None)).Returns(Task.CompletedTask);

        var response = new SaveRede(_redeRepositoryMock.Object,_unitOfWorkMock.Object);
        var output = await response.Handle(inserir,CancellationToken.None);
        // Assert
        Assert.NotNull(output);
        Assert.NotEqual(Guid.Empty, output.codigo);
    }
}