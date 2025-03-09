using Pessoa.Domain.Exception;
using Pessoa.Domain.Validation;

namespace Pessoa.UnitTest.Domain.Validation;

public class ValidacaoDominioTest
{
    [Fact(DisplayName = nameof(ValidacaoDominicoQuandoTargetNuloEmiteExcecaoDominio))]
    [Trait("Dominio", "Validation - ValidacaoDominio")]
    public void ValidacaoDominicoQuandoTargetNuloEmiteExcecaoDominio()
    {
        var resposta =  Assert.Throws<ExcecaoDeDominio>(() => ValidacaoDominio.EhNull(null, "nome"));
       
        Assert.Equal($"O campo nome deveria ser nulo",resposta.Message);
    }

    [Fact(DisplayName = nameof(ValidacaoDominioCampoVazioRetornaEmiteExcecaoDominio))]
    [Trait("Dominio", "Validation - ValidacaoDominio")]
    public void ValidacaoDominioCampoVazioRetornaEmiteExcecaoDominio()
    {
        var resposta =  Assert.Throws<ExcecaoDeDominio>(() => ValidacaoDominio.CampoVazio(string.Empty, "nome"));
       
        Assert.Equal($"O campo nome tem que ser preenchido",resposta.Message);
    }

        
    [Fact(DisplayName = nameof(ValidacaoDominioMinLengthRetornaEmiteExcecaoDominio))]
    [Trait("Dominio", "Validation - ValidacaoDominio")]
    public void ValidacaoDominioMinLengthRetornaEmiteExcecaoDominio()
    {
        int minLength = 5;
        string nomeCampo = "nome";
        var resposta = Assert.Throws<ExcecaoDeDominio>(() => ValidacaoDominio.MinLength("ere",minLength, nomeCampo));
        Assert.Equal($"O campo {nomeCampo} tem que ter ao menos {minLength} caracteres",resposta.Message);
        
    }

    [Fact(DisplayName = nameof(ValidacaoDominioMaxLengthRetornaEmiteExcecaoDominio))]
    [Trait("Dominio", "Validation - ValidacaoDominio")]
    public void ValidacaoDominioMaxLengthRetornaEmiteExcecaoDominio()
    {
      
        int maxLength = 5;
        string nomeCampo = "nome";
        var resposta = Assert.Throws<ExcecaoDeDominio>(() => ValidacaoDominio.MaxLength("ddddooooodd",maxLength, nomeCampo));
        Assert.Equal($"O campo {nomeCampo} tem que ter menos de {maxLength} caracteres",resposta.Message);
    }

    [Fact(DisplayName = nameof(ValidacaoDominioNumerosIguaisEmiteExcecaoDominio))]
    [Trait("Dominio", "validation - ValidacaoDominio")]
    public void ValidacaoDominioNumerosIguaisEmiteExcecaoDominio()
    {
        string numero = "2222222222";
        string campo = "cpf";
        
        var resposta = Assert.Throws<ExcecaoDeDominio>(() => ValidacaoDominio.TodosNumerosIguais(numero, campo));
        Assert.Equal($"O campo {campo} possui números iguais",resposta.Message);
    }

    [Fact(DisplayName = nameof(ValidacaoDominioRetornarTrueQuandoCpfForValido))]
    [Trait("Dominio", "validation - ValidacaoDominio")]
    public void ValidacaoDominioRetornarTrueQuandoCpfForValido()
    {
        string cpf = "82340788013";
        var resposta = ValidacaoDominio.ValidarCPF(cpf);
        
        Assert.True(resposta);
    }
    [Fact(DisplayName = nameof(ValidacaoDominioEmiteExcecaoDominio))]
    [Trait("Dominio", "validation - ValidacaoDominio")]
    public void ValidacaoDominioEmiteExcecaoDominio()
    {
        string cpf = "11122222222";
        
        var resposta = Assert.Throws<ExcecaoDeDominio>(() => ValidacaoDominio.ValidarCPF(cpf));
        Assert.Equal("Cpf inválido",resposta.Message); 
    }
    
    [Fact(DisplayName = nameof(ValidacaoDominioEmiteExcecaoDominioQuandoNumerosIguais))]
    [Trait("Dominio", "validation - ValidacaoDominio")]
    public void ValidacaoDominioEmiteExcecaoDominioQuandoNumerosIguais()
    {
        string cpf = "22222222222";
        
        var resposta = Assert.Throws<ExcecaoDeDominio>(() => ValidacaoDominio.ValidarCPF(cpf));
        Assert.Equal("Todos os números são iguais",resposta.Message); 
    }
    
    [Fact(DisplayName = nameof(ValidacaoDominioEmiteExcecaoDominioQuandoForMenorQueOnze))]
    [Trait("Dominio", "validation - ValidacaoDominio")]
    public void ValidacaoDominioEmiteExcecaoDominioQuandoForMenorQueOnze()
    {
        string cpf = "222222222";
        
        var resposta = Assert.Throws<ExcecaoDeDominio>(() => ValidacaoDominio.ValidarCPF(cpf));
        Assert.Equal("Número de digitos diferente de 11",resposta.Message); 
    }
    
    [Fact(DisplayName = nameof(ValidacaoDominioEmiteExcecaoDominioQuandoForMaiorQueOnze))]
    [Trait("Dominio", "validation - ValidacaoDominio")]
    public void ValidacaoDominioEmiteExcecaoDominioQuandoForMaiorQueOnze()
    {
        string cpf = "22222222222222222";
        
        var resposta = Assert.Throws<ExcecaoDeDominio>(() => ValidacaoDominio.ValidarCPF(cpf));
        Assert.Equal("Número de digitos diferente de 11",resposta.Message); 
    }
}