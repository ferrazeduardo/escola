using Rede.Domain.Events;
using Rede.Domain.SeedWork;
using Rede.Domain.Validation;

namespace Rede.Domain.Entity;

public class Rede : AggregateRoot
{
    public Rede(string razaoSocial, string nrCnpj,int codigoUsuario, List<DiaVencimento> diasVencimento)
    {
        RZ_SOCIAL = razaoSocial;
        NR_CNPJ = nrCnpj;
        DH_REGISTRO = DateTime.Now;
        US_REGISTRO = codigoUsuario;
        SetDiaVencimento(diasVencimento);
        Ativar();

        ValidacaoInserir();
        AddDomainEvent(new RedeSalvarEvent(razaoSocial,Id));
    }

    public Rede()
    {
    }
    private void ValidacaoInserir()
    {
        ValidacaoDominio.MaxLength(RZ_SOCIAL, 20, "razaoSocial");
        ValidacaoDominio.MinLength(RZ_SOCIAL,5, "razaoSocial");
        ValidacaoDominio.EhNull(RZ_SOCIAL, "razaoSocial");
        ValidacaoDominio.CampoVazio(RZ_SOCIAL, "razaoSocial");

        var cnpjApenasDigitos = ApenasDigitosCnpj();
        ValidacaoDominio.MaxLength(cnpjApenasDigitos,14, "cnpj");
        ValidacaoDominio.MinLength(cnpjApenasDigitos,1, "cnpj");
        ValidacaoDominio.EhNull(cnpjApenasDigitos, "cnpj");
        ValidacaoDominio.CampoVazio(cnpjApenasDigitos, "cnpj");

        ValidacaoDominio.Quando(QuantidadeDiasVencimentos() == 0, "Falta escolher um dia de vencimento");
        ValidacaoDominio.Quando(NaoPodeExistirDiaNegativo(), "Os dias de vencimento devem ser positivos");
        
        
    }

    private bool NaoPodeExistirDiaNegativo()
    {
        return DiaVencimentos.FirstOrDefault(diaVencimento => diaVencimento.Dia <= 0) is not null;
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


    public ICollection<DiaVencimento> DiaVencimentos { get; private set; } = new List<DiaVencimento>();
    

    public void Ativar()
    {
        ST_REDE = "S";
    }

    public void Desativar()
    {
        ST_REDE = "N";
    }
    
    public void AddDiaVencimento(DiaVencimento diaVencimento)
    {
        DiaVencimentos.Add(diaVencimento);
    }

  
    public void SetDiaVencimento(List<DiaVencimento> diasVencimento) => DiaVencimentos = diasVencimento;


    public void RemoveVencimento(DiaVencimento diaVencimento)
    {
        DiaVencimentos.Remove(diaVencimento);
    }



    public void RemoveAllDiasVencimentos()
    {
        DiaVencimentos.Clear();
    }
    
    public int QuantidadeDiasVencimentos() => DiaVencimentos.Count;

    
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

}