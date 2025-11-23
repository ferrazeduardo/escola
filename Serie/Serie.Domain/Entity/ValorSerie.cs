using System;

namespace Serie.Domain.Entity;

public class ValorSerie : SeedWorks.Entity
{

    public ValorSerie()
    {
        
    }

    public ValorSerie(Decimal valor,String turno,Serie serie)
    {
        Serie = serie;
        VL_Serie = valor;
        DS_TURNO = turno;
    }

    public Serie Serie { get; private set; }
    public Decimal VL_Serie { get; private set; }
    public String DS_TURNO { get; private set; }
}
