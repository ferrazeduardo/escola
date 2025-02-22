using Moq;
using Rede.Domain.Entity;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Test.UnitTest.Application.UseCase.UnidadeUseCase.AddUnidade;

[Collection(nameof(AddUnidadeFixture))]
public class AddUnidadeTest
{
    private readonly AddUnidadeFixture _fixture;
    private readonly Mock<IRedeRepository> _redeRepositoryMock;
    
    public AddUnidadeTest(AddUnidadeFixture fixture)
    {
        _fixture = fixture;
        _redeRepositoryMock = _fixture.redeRepositoryMock();
    }

    [Fact(DisplayName = nameof(RetornarIdQuandoAdicionarUnidade))]
    [Trait("Application", "UseCase - UnidadeUseCase - AddUnidade")]
    public async Task RetornarIdQuandoAdicionarUnidade()
    {
        var addUnidadeInput = _fixture.ObterAddUnidadeInput();
        Rede.Domain.Entity.Rede rede = new();
        addUnidadeInput.id_rede = rede.Id;
        
        _redeRepositoryMock.Setup(r => r.ObterPorId(addUnidadeInput.id_rede)).ReturnsAsync(rede);

        _redeRepositoryMock.Setup(r => r.AddUnidade(addUnidadeInput.id_rede, It.IsAny<Unidade>()))
            .Returns(Task.CompletedTask);

        var response = new Rede.Application.UseCases.UnidadeUseCase.AddUnidade.AddUnidade(_redeRepositoryMock.Object);
        
        var output = await response.Handle(addUnidadeInput,CancellationToken.None);

        Assert.NotNull(output);
        Assert.NotEqual(Guid.Empty, output.id_unidade);
    }

    [Fact(DisplayName = nameof(LancarExcecptionQuandoRedeForNulo))]
    [Trait("Application", "UseCase - UnidadeUseCase - AddUnidade")]
    public async Task LancarExcecptionQuandoRedeForNulo()
    {
        var addUnidadeInput = _fixture.ObterAddUnidadeInput();
        Rede.Domain.Entity.Rede rede = null;
        
        _redeRepositoryMock.Setup(r => r.ObterPorId(addUnidadeInput.id_rede)).ReturnsAsync(rede);
        var addUnidade = new Rede.Application.UseCases.UnidadeUseCase.AddUnidade.AddUnidade(_redeRepositoryMock.Object);
        var response = Assert.ThrowsAsync<Exception>(async () => await  addUnidade.Handle(addUnidadeInput,CancellationToken.None)).Result;
        
        Assert.Equal("Rede não existe",response.Message);
    }
    
}