using Rede.Domain.Exception;
using Rede.Domain.Validation;
using Rede.Domain.ValueObject;

namespace Rede.Domain.Entity;

public class Unidade : SeedWork.AggregateRoot
{
  

    public string DS_ENDERECO { get; set; }
    public string NR_CEP { get; set; }
    public Boolean ST_UNIDADE { get; set; }
    public DateTime DH_REGISTRO { get; set; }
    public string NR_UNIDADE { get; set; }
    public int US_REGISTRO { get; set; }
    public ICollection<Telefone> Telefones { get; private set; } = new List<Telefone>();

    public ICollection<Sala> Salas { get; private set; } = [];
    public Unidade()
    {

    }

    public Unidade(string endereco, string cep, string numeroUnidade, int usuarioRegistro, string dsComplmento)
    {
        this.DS_ENDERECO = endereco;
        this.NR_CEP = cep;
        this.NR_UNIDADE = numeroUnidade;
        this.US_REGISTRO = usuarioRegistro;
        this.DS_COMPLMENTO = dsComplmento;
        this.DH_REGISTRO = DateTime.UtcNow;
        Ativar();
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

    public void Ativar()
    {
        ST_UNIDADE = true;
    }

    public void Desativar()
    {
        ST_UNIDADE = false;
    }

    public void Update(string endereco, string cep, string numeroUnidade,bool status, string dsComplmento)
    {
        DS_ENDERECO = endereco;
        NR_CEP = cep;
        NR_UNIDADE = numeroUnidade;
        ST_UNIDADE = status;
        DS_COMPLMENTO = dsComplmento;
    }
}