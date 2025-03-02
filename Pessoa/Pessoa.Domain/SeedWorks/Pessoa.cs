using Pessoa.Domain.Entity;

namespace Pessoa.Domain.SeedWorks;

public  abstract class Pessoa : Entity
{
    private List<Telefone> _telefone;
    public string NR_CPF { get; set; }
    public string NR_RG { get; set; }
    public string NM_NOME { get; set; }
    public DateTime DT_NASCIMENTO { get; set; }
    public DateTime DH_REGISTRO { get; set; }
    public IReadOnlyList<Telefone> Telefone => _telefone.AsReadOnly();
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
  
}