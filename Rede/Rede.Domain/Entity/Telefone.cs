namespace Rede.Domain.Entity;

public class Telefone : SeedWork.Entity
{
    public Telefone(string NR_TELEFONE)
    {
        this.NR_TELEFONE = NR_TELEFONE;
    }

    public Telefone()
    {
        
    }
    
    public string NR_TELEFONE { get; set; }
    public Unidade Unidade { get; private set; }

}