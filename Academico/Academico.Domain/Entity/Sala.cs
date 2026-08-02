using System;

namespace Academico.Domain.Entity;

public class Sala
{
    public Sala(string nR_SALA, int qT_MAXIMA)
    {
        NR_SALA = nR_SALA;
        QT_MAXIMA = qT_MAXIMA;
    }

    public string NR_SALA { get; }
    public int QT_MAXIMA { get; }
}
