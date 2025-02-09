using Rede.Domain.Validation;

namespace Rede.Test.UnitTest.Domain.Entity.Validation;

public class ValidacaoDominioTest
{
    [Fact(DisplayName = nameof(ValidacaoDominicoQuandoTargetNulo))]
    [Trait("Dominio", "Validation - ValidacaoDominio")]
    public void ValidacaoDominicoQuandoTargetNulo()
    {
       var resposta =   ValidacaoDominio.EhNull(null, "nome");
       
       Assert.True(resposta.response);
       Assert.Equal($"O campo nome deveria ser nulo",resposta.mensagem);
    }

    [Fact(DisplayName = nameof(ValidacaoDominicoEhNuloRetonaFalseQuandoTargetNaoNulo))]
    [Trait("Dominio", "Validation - ValidacaoDominio")]
    public void ValidacaoDominicoEhNuloRetonaFalseQuandoTargetNaoNulo()
    {
        var resposta =   ValidacaoDominio.EhNull("dsdsdsd", "nome");
       
        Assert.False(resposta.response);
        Assert.Equal($"",resposta.mensagem);
    }

    [Fact(DisplayName = nameof(ValidacaoDominioCampoVazioRetornaTrue))]
    [Trait("Dominio", "Validation - ValidacaoDominio")]
    public void ValidacaoDominioCampoVazioRetornaTrue()
    {
        var resposta =   ValidacaoDominio.CampoVazio(string.Empty, "nome");
       
        Assert.True(resposta.response);
        Assert.Equal($"O campo nome tem que ser preenchido",resposta.mensagem);
    }
    
    [Fact(DisplayName = nameof(ValidacaoDominioCampoVazioRetornaFalseQuandoTargetForNaoVazio))]
    [Trait("Dominio", "Validation - ValidacaoDominio")]
    public void ValidacaoDominioCampoVazioRetornaFalseQuandoTargetForNaoVazio()
    {
        var resposta =   ValidacaoDominio.CampoVazio("fasdasdqwe", "nome");
       
        Assert.False(resposta.response);
        Assert.Equal($"",resposta.mensagem);
    }
    
    [Fact(DisplayName = nameof(ValidacaoDominioCampoVazioRetornaFalseQuandoTargetForNaoVazio))]
    [Trait("Dominio", "Validation - ValidacaoDominio")]
    public void ValidacaoDominioMinLengthRetornaTrue()
    {
        int minLength = 5;
        string nomeCampo = "nome";
        var resposta = ValidacaoDominio.MinLength("ere",minLength, nomeCampo);
        Assert.True(resposta.response);
        Assert.Equal($"O campo {nomeCampo} tem que ter ao menos {minLength} caracteres",resposta.mensagem);
        
    }

    [Fact(DisplayName = nameof(ValidacaoDominioCampoVazioRetornaFalseQuandoTargetForNaoVazio))]
    [Trait("Dominio", "Validation - ValidacaoDominio")]
    public void ValidacaoDominioMinLengthRetornaFalseQuandoTargetMaiorQueValorMinimo()
    {
      
        int minLength = 5;
        string nomeCampo = "nome";
        var resposta = ValidacaoDominio.MinLength("ppppppppppppppppp",minLength, nomeCampo);
        Assert.False(resposta.response);
        Assert.Equal($"",resposta.mensagem);
    }
    
    
    [Fact(DisplayName = nameof(ValidacaoDominioMaxLengthRetornaTrue))]
    [Trait("Dominio", "Validation - ValidacaoDominio")]
    public void ValidacaoDominioMaxLengthRetornaTrue()
    {
      
        int maxLength = 5;
        string nomeCampo = "nome";
        var resposta = ValidacaoDominio.MaxLength("ddddooooodd",maxLength, nomeCampo);
        Assert.True(resposta.response);
        Assert.Equal($"O campo {nomeCampo} tem que ter menos de {maxLength} caracteres",resposta.mensagem);
    }
    
    [Fact(DisplayName = nameof(ValidacaoDominioMaxLengthRetornaFalseQuandoTargetMaiorQueValorMaximo))]
    [Trait("Dominio", "Validation - ValidacaoDominio")]
    public void ValidacaoDominioMaxLengthRetornaFalseQuandoTargetMaiorQueValorMaximo()
    {
      
        int maxLength = 5;
        string nomeCampo = "nome";
        var resposta = ValidacaoDominio.MaxLength("pp",maxLength, nomeCampo);
        Assert.False(resposta.response);
        Assert.Equal($"",resposta.mensagem);
    }
}