namespace Rede.Domain.Entity;

public class Rede : SeedWork.Entity
{
    public Rede(string dsRede, string nrCnpj,int codigoUsuario)
    {
        DS_REDE = dsRede;
        NR_CNPJ = nrCnpj;
        DH_REGISTRO = DateTime.Now;
        US_REGISTRO = codigoUsuario;
        _unidades = new List<Unidade>();
        Ativar();

        ValidacaoAdd();
    }

    public Rede()
    {
        _unidades = new List<Unidade>();
    }
    private void ValidacaoAdd()
    {
        throw new NotImplementedException();
    }

    private void ValidacaoUpdate()
    {
        throw new NotImplementedException();
    }

    public void Update(string dsRede)
    {
        DS_REDE = dsRede;
        
        
    }
    public string DS_REDE { get; set; }
    public string NR_CNPJ { get; set; }
    public DateTime DH_REGISTRO { get; set; }
    public int US_REGISTRO { get; set; }
    public string ST_REDE { get; set; }

    public List<Unidade> Unidades { get; set; }
    
    public IReadOnlyList<Unidade> Categories 
        => _unidades.AsReadOnly();

    private List<Unidade> _unidades;

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