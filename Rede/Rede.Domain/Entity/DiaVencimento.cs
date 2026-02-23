namespace Rede.Domain.Entity;

public class DiaVencimento : SeedWork.Entity
{
    public DiaVencimento(int dia)
    {
        Dia = dia;
    }

    public DiaVencimento()
    {
        
    }
    public int Dia { get; set; }

    public Rede Rede { get; private set; } = new();
    
    
    
    public void SetRede(Rede rede)
    {
        Rede = rede;
    }
    
}