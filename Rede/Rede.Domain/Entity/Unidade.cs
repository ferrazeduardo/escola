namespace Rede.Domain.Entity;

public class Unidade
{
    public int CD_UNIDADE { get; set; }
    public string DS_UNIDADE { get; set; }
    public string DS_ENDERECO { get; set; }
    public int CD_REDE { get; set; }
    public string NR_CNPJ { get; set; }
    public string NR_CEP { get; set; }
    public string ST_UNIDADE { get; set; }
    public DateTime DH_REGISTRO { get; set; }
    public int US_REGISTRO { get; set; }
    public List<Telefone> Telefones { get; set; }

    public void Ativar()
    {
        ST_UNIDADE = "S";
    }

    public void Desativar()
    {
        ST_UNIDADE = "N";
    }
}