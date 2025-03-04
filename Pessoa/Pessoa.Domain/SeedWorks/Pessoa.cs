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
        ValidacaoDominio.EhNull(NM_NOME,"nome");
        ValidacaoDominio.CampoVazio(NM_NOME,"nome");
        ValidacaoDominio.MaxLength(NM_NOME, 100,"nome");
        ValidacaoDominio.MinLength(NM_NOME, 7,"nome");

        ValidacaoDominio.ValidarCPF(NR_CPF);
        
        ValidacaoDominio.EhNull(NR_RG,"rg");
        ValidacaoDominio.CampoVazio(NR_RG,"rg");
        ValidacaoDominio.MaxLength(NR_RG,60,"rg");
        ValidacaoDominio.MinLength(NR_RG,0,"rg");
        
        ValidacaoDominio.Quando(DT_NASCIMENTO < new DateTime(1920,1,1), "data de nascimento tem que ser maior que 1/1/1920");
        
        ValidacaoDominio.EhNull(DS_ENDERECO,"endereço");
        ValidacaoDominio.CampoVazio(DS_ENDERECO,"endereço");
        ValidacaoDominio.MaxLength(DS_ENDERECO,200,"endereço");
        ValidacaoDominio.MinLength(DS_ENDERECO,0,"endereço");
        
        ValidacaoDominio.MaxLength(UF,2,"UF");
        ValidacaoDominio.MinLength(UF,0,"UF");
        
        ValidacaoDominio.Quando(_telefone.Count == 0, "esta faltando adicionar um telefone");
        
        ValidacaoDominio.EhNull(NR_ENDERECO,"número de endereco");
        ValidacaoDominio.CampoVazio(NR_ENDERECO,"número de endereco");
    }
}