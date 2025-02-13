using Rede.Domain.Exception;
using Rede.Domain.Validation;

namespace Rede.Test.UnitTest.Domain.Entity.Validation;

public class ValidacaoDominioTest
{
    [Fact(DisplayName = nameof(ValidacaoDominicoQuandoTargetNulo))]
    [Trait("Dominio", "Validation - ValidacaoDominio")]
    public void ValidacaoDominicoQuandoTargetNulo()
    {
       var resposta =  Assert.Throws<ExcecaoDeDominio>(() => ValidacaoDominio.EhNull(null, "nome"));
       
       Assert.Equal($"O campo nome deveria ser nulo",resposta.Message);
    }


    [Fact(DisplayName = nameof(ValidacaoDominioCampoVazioRetornaTrue))]
    [Trait("Dominio", "Validation - ValidacaoDominio")]
    public void ValidacaoDominioCampoVazioRetornaTrue()
    {
        var resposta =  Assert.Throws<ExcecaoDeDominio>(() => ValidacaoDominio.CampoVazio(string.Empty, "nome"));
       
        Assert.Equal($"O campo nome tem que ser preenchido",resposta.Message);
    }
 
    
    [Fact(DisplayName = nameof(ValidacaoDominioMinLengthRetornaTrue))]
    [Trait("Dominio", "Validation - ValidacaoDominio")]
    public void ValidacaoDominioMinLengthRetornaTrue()
    {
        int minLength = 5;
        string nomeCampo = "nome";
        var resposta = Assert.Throws<ExcecaoDeDominio>(() => ValidacaoDominio.MinLength("ere",minLength, nomeCampo));
        Assert.Equal($"O campo {nomeCampo} tem que ter ao menos {minLength} caracteres",resposta.Message);
        
    }

    
    
    
    [Fact(DisplayName = nameof(ValidacaoDominioMaxLengthRetornaTrue))]
    [Trait("Dominio", "Validation - ValidacaoDominio")]
    public void ValidacaoDominioMaxLengthRetornaTrue()
    {
      
        int maxLength = 5;
        string nomeCampo = "nome";
        var resposta = Assert.Throws<ExcecaoDeDominio>(() => ValidacaoDominio.MaxLength("ddddooooodd",maxLength, nomeCampo));
        Assert.Equal($"O campo {nomeCampo} tem que ter menos de {maxLength} caracteres",resposta.Message);
    }
    
}