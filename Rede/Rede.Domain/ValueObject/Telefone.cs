using Rede.Domain.SeedWork;

namespace Rede.Domain.ValueObject;

public class Telefone : SeedWork.ValueObject
{
    public Telefone(string NR_TELEFONE)
    {
        this.NR_TELEFONE = NR_TELEFONE;
    }

    public Telefone()
    {

    }

    public string NR_TELEFONE { get; }

    public override int GetHashCode()
        => NR_TELEFONE.GetHashCode();

    public override bool Equals(SeedWork.ValueObject? obj)
    {
         if (obj is not Telefone other)
            return false;

        return NR_TELEFONE == other.NR_TELEFONE;
    }
}