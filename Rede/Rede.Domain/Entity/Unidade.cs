namespace Rede.Domain.Entity;

public class Unidade : SeedWork.Entity
{
    public string DS_ENDERECO { get; set; }
    public string NR_CEP { get; set; }
    public string ST_UNIDADE { get; set; }
    public DateTime DH_REGISTRO { get; set; }
    public string NR_UNIDADE { get; set; }
    public int US_REGISTRO { get; set; }
    public ICollection<Telefone> Telefones { get; private set; } = new List<Telefone>();


    public Unidade(
        string endereco,
        string cep,
        string numeroUnidade,
        int usuarioRegistro,
        string dsComplmento,
        Rede rede)
    {
        DS_ENDERECO = endereco;
        NR_CEP = cep;
        NR_UNIDADE = numeroUnidade;
        US_REGISTRO = usuarioRegistro;
        DH_REGISTRO = DateTime.Now;
        Rede = rede;
        DS_COMPLMENTO = dsComplmento;
        ST_UNIDADE = "S"; // Assumindo que a unidade inicia ativa
    }

    public Unidade()
    {
        
    }

    public void AddTelefone(Telefone telefone)
    {
        Telefones.Add(telefone);
    }
    
    public void RemoveTelefone(Telefone telefone)
    {
        Telefones.Remove(telefone);
    }

    public void SetTelefones(List<Telefone> telefones) => Telefones = telefones;

    public string DS_COMPLMENTO { get; set; }
    public Rede? Rede { get; private set; }

    public void Ativar()
    {
        ST_UNIDADE = "S";
    }

    public void Desativar()
    {
        ST_UNIDADE = "N";
    }
}