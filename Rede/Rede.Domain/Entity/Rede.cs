namespace Rede.Domain.Entity;

public class Rede
{
    public int CD_REDE { get; set; }
    public string DS_REDE { get; set; }
    public string ST_REDE { get; set; }
    public DateTime DH_REGISTRO { get; set; }
    public int US_REGISTRO { get; set; }

    public List<Unidade> Unidades { get; set; }

    public void Ativar()
    {
        ST_REDE = "S";
    }

    public void Desativar()
    {
        ST_REDE = "N";
    }
}