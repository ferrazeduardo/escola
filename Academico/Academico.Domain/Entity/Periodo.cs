using System;
using Academico.Domain.SeedWork;

namespace Academico.Domain.Entity;

public class Periodo : AggregateRoot
{
    public Periodo(int nR_ANO)
    {
        NR_ANO = nR_ANO;
    }

    public Periodo()
    {
        
    }

    public int NR_ANO { get; set; }
    public string ST_PERIODO { get; set; }

    
}
