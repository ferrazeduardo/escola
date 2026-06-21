using System;
using Academico.Domain.SeedWork;

namespace Academico.Domain.Entity;

public class Periodo : AggregateRoot
{
    public Periodo(int nR_ANO,DateTime dataInicio, DateTime dataFim)
    {
        NR_ANO = nR_ANO;
        DT_INICIO = dataInicio;
        DT_FIM = dataFim;
    }

    public Periodo()
    {
        
    }

    public int NR_ANO { get; set; }
    public string ST_PERIODO { get; set; }

    public DateTime DT_INICIO { get; set; }
    public DateTime DT_FIM { get; set; }

    
}
