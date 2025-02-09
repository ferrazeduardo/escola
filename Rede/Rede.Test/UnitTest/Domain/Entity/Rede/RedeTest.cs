using domain = Rede.Domain.Entity;

namespace Rede.Test.Domain.Entity;

public class RedeTest
{
    [Fact(DisplayName = nameof(AtivarTest))]
    [Trait("Domain","Rede")]
    public void AtivarTest()
    {
        domain.Rede rede = new();
        rede.Ativar();
        
        Assert.Equal("S",rede.ST_REDE);
        
    }

    [Fact(DisplayName = nameof(DesativarTest))]
    [Trait("Domain", "Rede")]
    public void DesativarTest()
    {
        domain.Rede rede = new();
        rede.Desativar();
        
        Assert.Equal("N",rede.ST_REDE);
    }
}