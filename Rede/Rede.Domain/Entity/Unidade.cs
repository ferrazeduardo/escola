using Rede.Domain.Exception;
using Rede.Domain.Validation;

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

    public ICollection<Sala> Salas { get; private set; } = [];
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
        DH_REGISTRO = DateTime.UtcNow;
        Rede = rede;
        DS_COMPLMENTO = dsComplmento;
        Ativar();
    }

    public Unidade()
    {

    }

    public void AddSala(Sala sala)
    {
        ExcecaoDeDominio.HaErro(Salas.FirstOrDefault(s => s.NR_SALA == sala.NR_SALA) is not null, "Sala já existe nesta unidade");
        Salas.Add(sala);
    }

    public void AddTelefone(Telefone telefone)
    {
        Telefones.Add(telefone);
    }
    public void AddTelefoneRange(List<string> telefones)
    {
        telefones.ForEach(t => Telefones.Add(new Telefone(t)));
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