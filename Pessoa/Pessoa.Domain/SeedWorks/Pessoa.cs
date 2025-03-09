using Pessoa.Domain.Entity;
using Pessoa.Domain.Validation;

namespace Pessoa.Domain.SeedWorks;

public  abstract class Pessoa : Entity
{
    public string NR_CPF { get; set; }
    public string NR_RG { get; set; }
    public string NM_NOME { get; set; }
    public string DS_ENDERECO { get; set; }
    public string NR_ENDERECO { get; set; }
    public string UF { get; set; }
    public DateTime DT_NASCIMENTO { get; set; }
    public DateTime DH_REGISTRO { get; set; }
    public IReadOnlyList<Telefone> Telefone => _telefone.AsReadOnly();
    private List<Telefone> _telefone;
    public int Idade()
    {
        DateTime dataAtual = DateTime.Today;
        int idade = dataAtual.Year - DT_NASCIMENTO.Year;

        // Verifica se a data de aniversário já passou neste ano
        if (dataAtual < DT_NASCIMENTO.AddYears(idade))
        {
             idade--;
        }

        return idade;

    }

    public void AddTelefone(Telefone telefone)
    {
        _telefone.Add(telefone);
    }

    public void RemoveTelefone(Telefone telefone)
    {
        _telefone.Remove(telefone);
    }

  
    public void Validacao()
    {
        ValidacaoDominio.EhNull(NM_NOME, "nome");    
        ValidacaoDominio.CampoVazio(NM_NOME, "nome");    
        ValidacaoDominio.MaxLength(NM_NOME, 200,"nome");    
        ValidacaoDominio.MinLength(NM_NOME,10,"nome");

        ValidacaoDominio.ValidarCPF(NR_CPF);
        
        ValidacaoDominio.EhNull(NR_RG,"rg");
        ValidacaoDominio.CampoVazio(NR_RG,"rg");
        ValidacaoDominio.MinLength(NR_RG,7,"rg");
        ValidacaoDominio.MaxLength(NR_RG,50,"rg");
        ValidacaoDominio.TodosNumerosIguais(NR_RG,"rg");
        
        
        ValidacaoDominio.EhNull(DS_ENDERECO,"endereço");
        ValidacaoDominio.CampoVazio(DS_ENDERECO,"endereço");
        ValidacaoDominio.MinLength(DS_ENDERECO,10,"endereço");
        ValidacaoDominio.MaxLength(DS_ENDERECO,200,"endereço");
        
        ValidacaoDominio.EhNull(NR_ENDERECO,"numero");
        ValidacaoDominio.CampoVazio(NR_ENDERECO,"numero");
        ValidacaoDominio.MaxLength(NR_ENDERECO,10,"numero");
        
        ValidacaoDominio.EhNull(UF,"uf");
        ValidacaoDominio.CampoVazio(UF,"uf");
        ValidacaoDominio.MaxLength(UF,2,"uf");
        
        ValidacaoDominio.Quando(DT_NASCIMENTO < new DateTime(1900,1,1),"data de nascimento invalida");

    }

    public void ValidacaoMaiorDeIdade()
    {
        ValidacaoDominio.Quando(Idade() < 18, "Idade tem que ser maior que 18 anos" );
    }
}