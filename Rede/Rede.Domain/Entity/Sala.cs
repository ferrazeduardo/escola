using System;
using Rede.Domain.Validation;

namespace Rede.Domain.Entity;

public class Sala
{
    public string NR_SALA { get; }
    public int QT_MAXIMA { get; }

    public Sala(string numeroSala, int quantidade)
    {
        NR_SALA = numeroSala;
        QT_MAXIMA = quantidade;
        ValidadorDeRegra.Novo()
       .Quando(string.IsNullOrEmpty(NR_SALA), "Número sala não pode ser vázio")
       .Quando(QT_MAXIMA <= 0, "Quantidade tem que ser maior que zero")
       .DispararExcecaoSeExistir();

    }

    public Sala()
    {

    }

    public override bool Equals(object obj)
    {
        if (obj is not Sala other)
            return false;

        return NR_SALA == other.NR_SALA;
    }

    public override int GetHashCode() => NR_SALA.GetHashCode();
}
