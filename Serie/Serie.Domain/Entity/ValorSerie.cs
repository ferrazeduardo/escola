using System;

namespace Serie.Domain.Entity;

public class ValorSerie : SeedWorks.Entity
{
 public ValorSerie(Decimal VL_SERIE, String DS_TURNO) {
        this.VL_SERIE = VL_SERIE;
        this.DS_TURNO = DS_TURNO;
    }

    public ValorSerie(Decimal vlSerie, String dsTurno, Guid id) {
        this.setId(id);
        this.VL_SERIE = vlSerie;
        this.DS_TURNO = dsTurno;
    }

  
 
    public String getDS_TURNO() {
        return DS_TURNO;
    }

    public Decimal VL_SERIE { get; private set; }
    public String DS_TURNO { get; private set; }
}
