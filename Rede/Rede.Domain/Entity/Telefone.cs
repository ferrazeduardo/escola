namespace Rede.Domain.Entity;

public class Telefone : SeedWork.Entity
{
    public Telefone(string NR_TELEFONE, Guid ID_UNIDADE)
    {
        this.ID_UNIDADE = ID_UNIDADE;
        this.NR_TELEFONE = NR_TELEFONE;
    }

    public Telefone()
    {
        
    }
    
    public string NR_TELEFONE { get; set; }
    public Guid ID_UNIDADE { get; set; }
    public Unidade Unidade { get; private set; }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        var entity = (Telefone)obj;
        return ID_UNIDADE == entity.ID_UNIDADE && NR_TELEFONE == entity.NR_TELEFONE;
    }
}