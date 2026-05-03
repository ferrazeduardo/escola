using Rede.Domain.Exception;
using Rede.Domain.SeedWork;
using Rede.Domain.Validation;

namespace Rede.Domain.Entity;

public class Rede : AggregateRoot
{
    public Rede(string razaoSocial, string nrCnpj,int codigoUsuario)
    {
        RZ_SOCIAL = razaoSocial;
        NR_CNPJ = nrCnpj;
        DH_REGISTRO = DateTime.UtcNow;
        US_REGISTRO = codigoUsuario;
        Ativar();

        // AddDomainEvent(new RedeSalvarEvent(razaoSocial,Id));
    }

    public Rede()
    {
    }
 

  

    private string ApenasDigitosCnpj()
    {
        return new string(NR_CNPJ.Where(char.IsDigit).ToArray());
    }


    private void ValidacaoUpdate()
    {
        throw new NotImplementedException();
    }

    public void Update(string dsRede)
    {
        RZ_SOCIAL = dsRede;
        ValidacaoUpdate();
    }
    public string RZ_SOCIAL { get; set; }
    public string NR_CNPJ { get; set; }
    public DateTime DH_REGISTRO { get; set; }
    public int US_REGISTRO { get; set; }
    public string ST_REDE { get; set; }
    
    public ICollection<Unidade> Unidades { get; private set; } = new List<Unidade>();


    public void Ativar()
    {
        ST_REDE = "S";
    }

    public void Desativar()
    {
        ST_REDE = "N";
    }
    
    public void AddUnidade(Unidade unidade)
    {
        Unidades.Add(unidade);
    }
    
    public void SetUnidades(List<Unidade> unidades) => Unidades = unidades;

    public void RemoveUnidade(Unidade unidade)
    {
        Unidades.Remove(unidade);
    }

    public void RemoveAllUnidades()
    {
        Unidades.Clear();
    }

    public Unidade GetUnidadeById(int unidadeId)
    {
        var unidade = Unidades.FirstOrDefault(u => u.Id == unidadeId);
        NotFounException.IsNull(unidade, "Unidade não encontrada");

        return unidade;
    }
}