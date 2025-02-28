namespace Pessoa.Domain.SeedWorks;

public  abstract class Pessoa : Entity
{
    public string NR_CPF { get; set; }
    public string NR_RG { get; set; }
    public string NM_NOME { get; set; }
    public DateTime DT_NASCIMENTO { get; set; }
    public DateTime DH_REGISTRO { get; set; }
  
}