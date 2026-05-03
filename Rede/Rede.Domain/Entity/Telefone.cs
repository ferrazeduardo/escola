namespace Rede.Domain.Entity;

public class Telefone
{
    public Telefone(string NR_TELEFONE)
    {
        this.NR_TELEFONE = NR_TELEFONE;
    }

    public Telefone()
    {

    }

    public string NR_TELEFONE { get; }

    public override bool Equals(object obj)
    {
        if (obj is not Telefone other)
            return false;

        return NR_TELEFONE == other.NR_TELEFONE;
    }

    public override int GetHashCode()
        => NR_TELEFONE.GetHashCode();
}