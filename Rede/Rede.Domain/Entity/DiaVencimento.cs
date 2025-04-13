namespace Rede.Domain.Entity;

public class DiaVencimento : SeedWork.Entity
{
    public DiaVencimento(int dia,Guid idRede)
    {
        Dia = dia;
        ID_REDE = idRede;
    }

    public DiaVencimento()
    {
        
    }
    public int Dia { get; set; }

    public Guid ID_REDE { get; set; }
    public Rede Rede { get; private set; }
    
    
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        var entity = (DiaVencimento)obj;
        return Dia == entity.Dia && ID_REDE == entity.ID_REDE;
    }
    
    
    
}