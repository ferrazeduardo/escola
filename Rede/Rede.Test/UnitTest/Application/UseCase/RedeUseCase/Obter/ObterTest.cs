using Moq;
using Rede.Application.UseCases.RedeUseCase.Obter;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Test.UnitTest.Application.UseCase.RedeUseCase.Obter;

[Collection(nameof(ObterTestFixture))]
public class ObterTest
{
    private readonly ObterTestFixture _fixture;
    private readonly Mock<IRedeRepository> _redeRepositoryMock;
    public ObterTest(ObterTestFixture fixture)
    {
        _fixture = fixture;
        _redeRepositoryMock = _fixture.redeRepositoryMock();
    }
    
    [Fact(DisplayName = nameof(ObterDeveRetornarUmRede))]
    [Trait("Application ","UseCase - RedeUseCase - Obter")]
    public async Task ObterDeveRetornarUmRede()
    {
        var rede = _fixture.GetRede();
        var input = new ObterRedeInput();
        input.id = rede.Id;
        _redeRepositoryMock.Setup(m => m.ObterPorId(input.id)).ReturnsAsync(rede);
        
        
        var response = new ObterRede(_redeRepositoryMock.Object);
        var output = await response.Handle(input, CancellationToken.None);

        Assert.Equal(output.rede.id, input.id);
        Assert.Equal("teste razao social", output.rede.razaoSocial);
        Assert.Equal("84949144000189", output.rede.cnpj);

    }
}