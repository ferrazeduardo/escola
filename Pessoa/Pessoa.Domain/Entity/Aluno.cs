using Pessoa.Domain.Exception;
using Pessoa.Domain.Validation;

namespace Pessoa.Domain.Entity;

public class Aluno : SeedWorks.Pessoa
{

    public Aluno(string NM_NOME,string NR_CPF, string NR_RG, string DS_ENDERECO,string NR_ENDERECO,string UF,DateTime DT_NASCIMENTO)
    {
        this.NM_NOME = NM_NOME;
        this.NR_CPF = NR_CPF;
        this.NR_RG = NR_RG;
        this.DS_ENDERECO = DS_ENDERECO;
        this.NR_ENDERECO = NR_ENDERECO;
        this.UF = UF;
        this.DT_NASCIMENTO = DT_NASCIMENTO;
        this.DH_REGISTRO = DateTime.Now;
        this.Validacao();
    }

    
    private Rede _rede;
    private Pai _pai;
    private Mae _mae;
    public void SetPai(Pai pai)
    {
        _pai = pai;
        Id_PAI = pai.Id;
    }

    public Pai GetPai()
    {
        return _pai;
    }

    public void SetMae(Mae mae)
    {
        _mae = mae;
        Id_MAE = mae.Id;
    }

    public Mae GetMae()
    {
        return _mae;
    }

    public void SetRede(Rede Rede)
    {
        _rede = Rede;
        Id_REDE = Rede.Id;
    }

    public Rede GetRede()
    {
        return _rede;
    }
    

}