namespace Rede.Domain.Entity;

public class DiaVencimento
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
}