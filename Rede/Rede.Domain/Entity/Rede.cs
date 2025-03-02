using Rede.Domain.Validation;

namespace Rede.Domain.Entity;

public class Rede : SeedWork.Entity
{
    public Rede(string razaoSocial, string nrCnpj,int codigoUsuario, List<DiaVencimento> diasVencimento)
    {
        RZ_SOCIAL = razaoSocial;
        NR_CNPJ = nrCnpj;
        DH_REGISTRO = DateTime.Now;
        US_REGISTRO = codigoUsuario;
        _unidades = new List<Unidade>();
        _diasVencimento = new List<DiaVencimento>();
        SetDiaVencimento(diasVencimento);
        Ativar();

        ValidacaoInserir();
    }

    public Rede()
    {
        _unidades = new List<Unidade>();
        _diasVencimento = new List<DiaVencimento>();
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
        return DiasVencimentos.FirstOrDefault(diaVencimento => diaVencimento.Dia <= 0) is not null;
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

    public IReadOnlyList<Unidade> Unidades 
        => _unidades.AsReadOnly();

    private List<Unidade> _unidades;


    public IReadOnlyList<DiaVencimento> DiasVencimentos
        => _diasVencimento.AsReadOnly();
    
    private List<DiaVencimento> _diasVencimento;

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
        _diasVencimento.Add(diaVencimento);
    }
    
    public void SetDiaVencimento(List<DiaVencimento> diasVencimento) => _diasVencimento = diasVencimento;

    public void RemoveVencimento(DiaVencimento diaVencimento)
    {
        _diasVencimento.Remove(diaVencimento);
    }

    public void RemoveAllDiasVencimentos()
    {
        _diasVencimento.Clear();
    }
    
    public int QuantidadeDiasVencimentos() => _diasVencimento.Count;

    
    public void AddUnidade(Unidade unidade)
    {
        _unidades.Add(unidade);
    }
    
    public void SetUnidades(List<Unidade> unidades) => _unidades = unidades;

    public void RemoveUnidade(Unidade unidade)
    {
        _unidades.Remove(unidade);
    }

    public void RemoveAllUnidades()
    {
        _unidades.Clear();
    }

}