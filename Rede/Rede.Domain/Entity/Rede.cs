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
       ExcecaoDeDominio.HaErro(string.IsNullOrWhiteSpace(RZ_SOCIAL), "Razão social não pode ser nula ou vazia");
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
    public bool ST_REDE { get; set; }
    
    public ICollection<int> Unidades { get; private set; } = [];


    public void Ativar()
    {
        ST_REDE = true;
    }

    public void Desativar()
    {
        ST_REDE = false;
    }
    
    public void RemoveAllUnidades()
    {
        Unidades.Clear();
    }

}