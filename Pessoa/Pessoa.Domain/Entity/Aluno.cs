namespace Pessoa.Domain.Entity;

public class Aluno : SeedWorks.Pessoa
{

    private Rede _rede;
    private Pai _pai;
    private Mae _mae;
    public void SetPai(Pai pai)
    {
        _pai = pai;
    }

    public Pai GetPai()
    {
        return _pai;
    }

    public void SetMae(Mae mae)
    {
        _mae = mae;
    }

    public Mae GetMae()
    {
        return _mae;
    }

    public void SetRede(Rede Rede)
    {
        _rede = Rede;
    }

    public Rede GetRede()
    {
        return _rede;
    }
}