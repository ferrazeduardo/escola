using Moq;
using Rede.Domain.Entity;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Test.UnitTest.Application.UseCase.DiaVencimentoUseCase.AddDiaVencimento;

[Collection(nameof(AddDiaVencimentoFixture))]
public class AddDiaVencimentoTest
{
    public readonly AddDiaVencimentoFixture _fixture;
    private readonly Mock<IRedeRepository> _redeRepositoryMock;

    public AddDiaVencimentoTest(AddDiaVencimentoFixture fixture)
    {
        _fixture = fixture;
        _redeRepositoryMock = _fixture.redeRepositoryMock();
    }

    [Fact(DisplayName = nameof(AddDiaVencimento))]
    [Trait("Application", "UseCase - DiaVencimentoUseCase - AddDiaVencimento")]
    public async Task AddDiaVencimento()
    {
        var addDiaVencimentoInput = _fixture.ObterAddDiaVencimentoInput();
        Rede.Domain.Entity.Rede rede = new();
        
        _redeRepositoryMock.Setup(r => r.ObterPorId(addDiaVencimentoInput.id_rede)).ReturnsAsync(rede);

        // _redeRepositoryMock.Setup(r => r.AddDiaVencimento(addDiaVencimentoInput.id_rede, It.IsAny<DiaVencimento>()))
        //     .Returns(Task.CompletedTask);

        var response = new Rede.Application.UseCases.DiaVencimentoUseCase.AddDiaVencimento.AddDiaVencimento(_redeRepositoryMock.Object);
        
        var output = await response.Handle(addDiaVencimentoInput,CancellationToken.None);

        Assert.True(output.vencimentos.Count == 1);
    }
    
    
    
    [Fact(DisplayName = nameof(LancarExcecptionQuandoRedeForNulo))]
    [Trait("Application", "UseCase - DiaVencimentoUseCase - AddDiaVencimento")]
    public async Task LancarExcecptionQuandoRedeForNulo()
    {
        var addDiaVencimentoInput = _fixture.ObterAddDiaVencimentoInput();
        Rede.Domain.Entity.Rede rede = null;
        
        _redeRepositoryMock.Setup(r => r.ObterPorId(addDiaVencimentoInput.id_rede)).ReturnsAsync(rede);
        var addUnidade = new Rede.Application.UseCases.DiaVencimentoUseCase.AddDiaVencimento.AddDiaVencimento(_redeRepositoryMock.Object);
        var response = Assert.ThrowsAsync<Exception>(async () => await  addUnidade.Handle(addDiaVencimentoInput,CancellationToken.None)).Result;
        
        Assert.Equal("Rede não existe",response.Message);
    }
}