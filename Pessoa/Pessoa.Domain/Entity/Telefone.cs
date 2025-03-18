namespace Pessoa.Domain.Entity;

public class Telefone : SeedWorks.Entity
{
    public Guid ID_PESSOA { get; private set; }
    public string NR_TELEFONE { get; set; }
    public SeedWorks.Pessoa Pessoa { get; private set; }
}