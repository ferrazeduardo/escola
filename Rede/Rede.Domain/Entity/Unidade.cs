namespace Rede.Domain.Entity;

public class Unidade : SeedWork.Entity
{
    public string DS_UNIDADE { get; set; }
    public string DS_ENDERECO { get; set; }
    public string NR_CEP { get; set; }
    public string ST_UNIDADE { get; set; }
    public DateTime DH_REGISTRO { get; set; }
    public int US_REGISTRO { get; set; }
    public IReadOnlyList<Telefone> Categories 
        => _telefones.AsReadOnly();

    private List<Telefone> _telefones;
    public void Ativar()
    {
        ST_UNIDADE = "S";
    }

    public void Desativar()
    {
        ST_UNIDADE = "N";
    }
}