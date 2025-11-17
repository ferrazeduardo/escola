using System;

namespace Serie.Domain.Entity;

public class Sala : SeedWorks.Entity
{
    public Sala(String numeroSala)
    {
        setNr_sala(numeroSala);
    }

    public void setNr_sala(String nr_sala) {
        this.NR_SALA = nr_sala;
    }

    public String NR_SALA { get; private set; }
    public Unidade Unidade { get; private set; }
}
