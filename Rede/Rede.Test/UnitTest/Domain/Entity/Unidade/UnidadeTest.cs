using domain = Rede.Domain.Entity;
namespace Rede.Test.Domain.Entity;

public class UnidadeTest
{
    [Fact(DisplayName = nameof(AtivarUnidadeTest))]
    [Trait("Domain", "Unidade")]
    public void AtivarUnidadeTest()
    {
        domain.Unidade unidade = new domain.Unidade();
        unidade.Ativar();
        
        Assert.Equal("S",unidade.ST_UNIDADE);
    }

    [Fact(DisplayName = nameof(DesativarUnidadeTest))]
    [Trait("Domain", "Unidade")]
    public void DesativarUnidadeTest()
    {
        domain.Unidade unidade = new domain.Unidade();
        unidade.Desativar();
        
        Assert.Equal("N",unidade.ST_UNIDADE);
    }
}