using Pessoa.Domain.Entity;
using Pessoa.Domain.Exception;

namespace Pessoa.UnitTest.Domain.Entity;

public class AlunoTest
{
    [Fact(DisplayName = nameof(LancarExcecaoDominioQuandoNomeForNull))]
    [Trait("Dominio", "Entity - Aluno")]
    public void LancarExcecaoDominioQuandoNomeForNull()
    {
        
        string nome = null;
        string cpf = "123.456.789-00";
        string rg = "MG-12.345.678";
        string endereco = "Rua das Flores";
        string numeroEndereco = "123";
        string uf = "MG";
        DateTime dataNascimento = new DateTime(2000, 1, 1);
        // Criação do objeto Aluno
        var response = Assert.Throws<ExcecaoDeDominio>(() => new Aluno(nome, cpf, rg, endereco, numeroEndereco, uf, dataNascimento));
        
        Assert.Equal($"O campo nome deveria ser nulo",response.Message);
        
        
    }
    
    [Fact(DisplayName = nameof(LancarExcecaoDominioQuandoNomeForCampoVazio))]
    [Trait("Dominio", "Entity - Aluno")]
    public void LancarExcecaoDominioQuandoNomeForCampoVazio()
    {
        
        string nome =  "";
        string cpf = "123.456.789-00";
        string rg = "MG-12.345.678";
        string endereco = "Rua das Flores";
        string numeroEndereco = "123";
        string uf = "MG";
        DateTime dataNascimento = new DateTime(2000, 1, 1);
        // Criação do objeto Aluno
        var response = Assert.Throws<ExcecaoDeDominio>(() => new Aluno(nome, cpf, rg, endereco, numeroEndereco, uf, dataNascimento));
        
        Assert.Equal($"O campo nome tem que ser preenchido",response.Message);
        
        
    }
    
    
    [Fact(DisplayName = nameof(LancarExcecaoDominioQuandoNomeForMaiorQueDuzendoCaracteres))]
    [Trait("Dominio", "Entity - Aluno")]
    public void LancarExcecaoDominioQuandoNomeForMaiorQueDuzendoCaracteres()
    {
        
        string nome =  new string('A', 201);
        string cpf = "123.456.789-00";
        string rg = "MG-12.345.678";
        string endereco = "Rua das Flores";
        string numeroEndereco = "123";
        string uf = "MG";
        DateTime dataNascimento = new DateTime(2000, 1, 1);
        // Criação do objeto Aluno
        var response = Assert.Throws<ExcecaoDeDominio>(() => new Aluno(nome, cpf, rg, endereco, numeroEndereco, uf, dataNascimento));
        
        Assert.Equal($"O campo nome tem que ter menos de 200 caracteres",response.Message);
        
        
    }
    
    [Fact(DisplayName = nameof(LancarExcecaoDominioQuandoNomeForMenorQueDezCaracteres))]
    [Trait("Dominio", "Entity - Aluno")]
    public void LancarExcecaoDominioQuandoNomeForMenorQueDezCaracteres()
    {
        
        string nome =  new string('A', 9);
        string cpf = "123.456.789-00";
        string rg = "MG-12.345.678";
        string endereco = "Rua das Flores";
        string numeroEndereco = "123";
        string uf = "MG";
        DateTime dataNascimento = new DateTime(2000, 1, 1);
        // Criação do objeto Aluno
        var response = Assert.Throws<ExcecaoDeDominio>(() => new Aluno(nome, cpf, rg, endereco, numeroEndereco, uf, dataNascimento));
        
        Assert.Equal($"O campo nome tem que ter ao menos 10 caracteres",response.Message);
        
        
    }
    
    [Fact(DisplayName = nameof(LancarExcecaoDominioQuandoCpfForInvalido))]
    [Trait("Dominio", "Entity - Aluno")]
    public void LancarExcecaoDominioQuandoCpfForInvalido()
    {
        
        string nome = "João Silva";
        string cpf = "123.456.789-00";
        string rg = "MG-12.345.678";
        string endereco = "Rua das Flores";
        string numeroEndereco = "123";
        string uf = "MG";
        DateTime dataNascimento = new DateTime(2000, 1, 1);
        // Criação do objeto Aluno
        var response = Assert.Throws<ExcecaoDeDominio>(() => new Aluno(nome, cpf, rg, endereco, numeroEndereco, uf, dataNascimento));
        
        Assert.Equal($"Cpf inválido",response.Message);
        
        
    }
    
    [Fact(DisplayName = nameof(LancarExcecaoDominioQuandoRgForNulo))]
    [Trait("Dominio", "Entity - Aluno")]
    public void LancarExcecaoDominioQuandoRgForNulo()
    {
        
        string nome = "João Silva";
        string cpf = "15019192023";
        string rg = null;
        string endereco = "Rua das Flores";
        string numeroEndereco = "123";
        string uf = "MG";
        DateTime dataNascimento = new DateTime(2000, 1, 1);
        // Criação do objeto Aluno
        var response = Assert.Throws<ExcecaoDeDominio>(() => new Aluno(nome, cpf, rg, endereco, numeroEndereco, uf, dataNascimento));
        
        Assert.Equal($"O campo rg deveria ser nulo",response.Message);
    }
    
    [Fact(DisplayName = nameof(LancarExcecaoDominioQuandoRgForVazio))]
    [Trait("Dominio", "Entity - Aluno")]
    public void LancarExcecaoDominioQuandoRgForVazio()
    {
        
        string nome = "João Silva";
        string cpf = "15019192023";
        string rg = "";
        string endereco = "Rua das Flores";
        string numeroEndereco = "123";
        string uf = "MG";
        DateTime dataNascimento = new DateTime(2000, 1, 1);
        // Criação do objeto Aluno
        var response = Assert.Throws<ExcecaoDeDominio>(() => new Aluno(nome, cpf, rg, endereco, numeroEndereco, uf, dataNascimento));
        
        Assert.Equal($"O campo rg tem que ser preenchido",response.Message);
    }
    [Fact(DisplayName = nameof(LancarExcecaoDominioQuandoRgTiverMenosDeSeteCaracteres))]
    [Trait("Dominio", "Entity - Aluno")]
    public void LancarExcecaoDominioQuandoRgTiverMenosDeSeteCaracteres()
    {
        
        string nome = "João Silva";
        string cpf = "15019192023";
        string rg = "2";
        string endereco = "Rua das Flores";
        string numeroEndereco = "123";
        string uf = "MG";
        DateTime dataNascimento = new DateTime(2000, 1, 1);
        // Criação do objeto Aluno
        var response = Assert.Throws<ExcecaoDeDominio>(() => new Aluno(nome, cpf, rg, endereco, numeroEndereco, uf, dataNascimento));
        
        Assert.Equal($"O campo rg tem que ter ao menos 7 caracteres",response.Message);
    }
    
    [Fact(DisplayName = nameof(LancarExcecaoDominioQuandoRgTiverMaisDeCincoentaCaracteres))]
    [Trait("Dominio", "Entity - Aluno")]
    public void LancarExcecaoDominioQuandoRgTiverMaisDeCincoentaCaracteres()
    {
        
        string nome = "João Silva";
        string cpf = "15019192023";
        string rg = new string('1',60);
        string endereco = "Rua das Flores";
        string numeroEndereco = "123";
        string uf = "MG";
        DateTime dataNascimento = new DateTime(2000, 1, 1);
        // Criação do objeto Aluno
        var response = Assert.Throws<ExcecaoDeDominio>(() => new Aluno(nome, cpf, rg, endereco, numeroEndereco, uf, dataNascimento));
        
        Assert.Equal($"O campo rg tem que ter menos de 50 caracteres",response.Message);
    }
    
    [Fact(DisplayName = nameof(LancarExcecaoDominioQuandoRgTiverTodosNumerosIguais))]
    [Trait("Dominio", "Entity - Aluno")]
    public void LancarExcecaoDominioQuandoRgTiverTodosNumerosIguais()
    {
        
        string nome = "João Silva";
        string cpf = "15019192023";
        string rg = new string('1',8);
        string endereco = "Rua das Flores";
        string numeroEndereco = "123";
        string uf = "MG";
        DateTime dataNascimento = new DateTime(2000, 1, 1);
        // Criação do objeto Aluno
        var response = Assert.Throws<ExcecaoDeDominio>(() => new Aluno(nome, cpf, rg, endereco, numeroEndereco, uf, dataNascimento));
        
        Assert.Equal($"O campo rg possui números iguais",response.Message);
    }
    
     [Fact(DisplayName = nameof(LancarExcecaoDominioQuandoEnderecoForNull))]
    [Trait("Dominio", "Entity - Aluno")]
    public void LancarExcecaoDominioQuandoEnderecoForNull()
    {
        
        string nome = "João Silva";
        string cpf = "15019192023";
        string rg = "MG-12.345.678";
        string endereco = null;
        string numeroEndereco = "123";
        string uf = "MG";
        DateTime dataNascimento = new DateTime(2000, 1, 1);
        // Criação do objeto Aluno
        var response = Assert.Throws<ExcecaoDeDominio>(() => new Aluno(nome, cpf, rg, endereco, numeroEndereco, uf, dataNascimento));
        
        Assert.Equal($"O campo endereço deveria ser nulo",response.Message);
        
        
    }
    
    [Fact(DisplayName = nameof(LancarExcecaoDominioQuandoEnderecoForCampoVazio))]
    [Trait("Dominio", "Entity - Aluno")]
    public void LancarExcecaoDominioQuandoEnderecoForCampoVazio()
    {
        
        string nome = "João Silva";
        string cpf = "15019192023";
        string rg = "MG-12.345.678";
        string endereco = "";
        string numeroEndereco = "123";
        string uf = "MG";
        DateTime dataNascimento = new DateTime(2000, 1, 1);
        // Criação do objeto Aluno
        var response = Assert.Throws<ExcecaoDeDominio>(() => new Aluno(nome, cpf, rg, endereco, numeroEndereco, uf, dataNascimento));
        
        Assert.Equal($"O campo endereço tem que ser preenchido",response.Message);
        
        
    }
    
    
    [Fact(DisplayName = nameof(LancarExcecaoDominioQuandoEnderecoForMaiorQueDuzendoCaracteres))]
    [Trait("Dominio", "Entity - Aluno")]
    public void LancarExcecaoDominioQuandoEnderecoForMaiorQueDuzendoCaracteres()
    {
        string nome = "João Silva";
        string cpf = "15019192023";
        string rg = "MG-12.345.678";
        string endereco = new string('A', 201);
        string numeroEndereco = "123";
        string uf = "MG";
        DateTime dataNascimento = new DateTime(2000, 1, 1);
        // Criação do objeto Aluno
        var response = Assert.Throws<ExcecaoDeDominio>(() => new Aluno(nome, cpf, rg, endereco, numeroEndereco, uf, dataNascimento));
        
        Assert.Equal($"O campo endereço tem que ter menos de 200 caracteres",response.Message);
        
        
    }
    
    [Fact(DisplayName = nameof(LancarExcecaoDominioQuandoEnderecoForMenorQueDezCaracteres))]
    [Trait("Dominio", "Entity - Aluno")]
    public void LancarExcecaoDominioQuandoEnderecoForMenorQueDezCaracteres()
    {
        
        string nome = "João Silva";
        string cpf = "15019192023";
        string rg = "MG-12.345.678";
        string endereco = new string('A', 9);
        string numeroEndereco = "123";
        string uf = "MG";
        DateTime dataNascimento = new DateTime(2000, 1, 1);
        // Criação do objeto Aluno
        var response = Assert.Throws<ExcecaoDeDominio>(() => new Aluno(nome, cpf, rg, endereco, numeroEndereco, uf, dataNascimento));
        
        Assert.Equal($"O campo endereço tem que ter ao menos 10 caracteres",response.Message);
        
        
    }
    
    
    [Fact(DisplayName = nameof(LancarExcecaoDominioQuandoNumeroEnderecoForNull))]
    [Trait("Dominio", "Entity - Aluno")]
    public void LancarExcecaoDominioQuandoNumeroEnderecoForNull()
    {
        
        string nome = "João Silva";
        string cpf = "15019192023";
        string rg = "MG-12.345.678";
        string endereco = "Rua das Flores";
        string numeroEndereco = null;
        string uf = "MG";
        DateTime dataNascimento = new DateTime(2000, 1, 1);
        // Criação do objeto Aluno
        var response = Assert.Throws<ExcecaoDeDominio>(() => new Aluno(nome, cpf, rg, endereco, numeroEndereco, uf, dataNascimento));
        
        Assert.Equal($"O campo numero deveria ser nulo",response.Message);
        
        
    }
    
    [Fact(DisplayName = nameof(LancarExcecaoDominioQuandoNumeroEnderecoForCampoVazio))]
    [Trait("Dominio", "Entity - Aluno")]
    public void LancarExcecaoDominioQuandoNumeroEnderecoForCampoVazio()
    {
        
        string nome = "João Silva";
        string cpf = "15019192023";
        string rg = "MG-12.345.678";
        string endereco = "Rua das Flores";
        string numeroEndereco = "";
        string uf = "MG";
        DateTime dataNascimento = new DateTime(2000, 1, 1);
        // Criação do objeto Aluno
        var response = Assert.Throws<ExcecaoDeDominio>(() => new Aluno(nome, cpf, rg, endereco, numeroEndereco, uf, dataNascimento));
        
        Assert.Equal($"O campo numero tem que ser preenchido",response.Message);
        
        
    }
    
    
  
    [Fact(DisplayName = nameof(LancarExcecaoDominioQuandoNumeroEnderecoForMaiorQueDezCaracteres))]
    [Trait("Dominio", "Entity - Aluno")]
    public void LancarExcecaoDominioQuandoNumeroEnderecoForMaiorQueDezCaracteres()
    {
        
        string nome = "João Silva";
        string cpf = "15019192023";
        string rg = "MG-12.345.678";
        string endereco = "Rua das Flores";
        string numeroEndereco =  new string('A', 19);
        string uf = "MG";
        DateTime dataNascimento = new DateTime(2000, 1, 1);
        // Criação do objeto Aluno
        var response = Assert.Throws<ExcecaoDeDominio>(() => new Aluno(nome, cpf, rg, endereco, numeroEndereco, uf, dataNascimento));
        
        Assert.Equal($"O campo numero tem que ter menos de 10 caracteres",response.Message);
        
        
    }
    
    
    [Fact(DisplayName = nameof(LancarExcecaoDominioQuandoUFForNull))]
    [Trait("Dominio", "Entity - Aluno")]
    public void LancarExcecaoDominioQuandoUFForNull()
    {
        
        string nome = "João Silva";
        string cpf = "15019192023";
        string rg = "MG-12.345.678";
        string endereco = "Rua das Flores";
        string numeroEndereco = "123";
        string uf = null;
        DateTime dataNascimento = new DateTime(2000, 1, 1);
        // Criação do objeto Aluno
        var response = Assert.Throws<ExcecaoDeDominio>(() => new Aluno(nome, cpf, rg, endereco, numeroEndereco, uf, dataNascimento));
        
        Assert.Equal($"O campo uf deveria ser nulo",response.Message);
        
        
    }
    
    [Fact(DisplayName = nameof(LancarExcecaoDominioQuandoNumeroEnderecoForCampoVazio))]
    [Trait("Dominio", "Entity - Aluno")]
    public void LancarExcecaoDominioQuandoUFCampoVazio()
    {
        
        string nome = "João Silva";
        string cpf = "15019192023";
        string rg = "MG-12.345.678";
        string endereco = "Rua das Flores";
        string numeroEndereco = "123";
        string uf = "";
        DateTime dataNascimento = new DateTime(2000, 1, 1);
        // Criação do objeto Aluno
        var response = Assert.Throws<ExcecaoDeDominio>(() => new Aluno(nome, cpf, rg, endereco, numeroEndereco, uf, dataNascimento));
        
        Assert.Equal($"O campo uf tem que ser preenchido",response.Message);
        
        
    }
    
    
  
    [Fact(DisplayName = nameof(LancarExcecaoDominioQuandoUFForMaiorQueDoisCaracteres))]
    [Trait("Dominio", "Entity - Aluno")]
    public void LancarExcecaoDominioQuandoUFForMaiorQueDoisCaracteres()
    {
        
        string nome = "João Silva";
        string cpf = "15019192023";
        string rg = "MG-12.345.678";
        string endereco = "Rua das Flores";
        string numeroEndereco = "123";
        string uf = "MGE";
        DateTime dataNascimento = new DateTime(2000, 1, 1);
        // Criação do objeto Aluno
        var response = Assert.Throws<ExcecaoDeDominio>(() => new Aluno(nome, cpf, rg, endereco, numeroEndereco, uf, dataNascimento));
        
        Assert.Equal($"O campo uf tem que ter menos de 2 caracteres",response.Message);
        
    }

    [Fact(DisplayName = nameof(DataNascimentoForInvalida))]
    [Trait("Dominio", "Entity - Aluno")]
    public void DataNascimentoForInvalida()
    {
        string nome = "João Silva";
        string cpf = "15019192023";
        string rg = "MG-12.345.678";
        string endereco = "Rua das Flores";
        string numeroEndereco = "123";
        string uf = "MG";
        DateTime dataNascimento = new DateTime(1800, 1, 1);
        // Criação do objeto Aluno
        var response = Assert.Throws<ExcecaoDeDominio>(() => new Aluno(nome, cpf, rg, endereco, numeroEndereco, uf, dataNascimento));
        
        Assert.Equal($"data de nascimento invalida",response.Message);
    }
}