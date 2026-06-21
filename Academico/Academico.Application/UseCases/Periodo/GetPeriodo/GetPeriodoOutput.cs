using System;
using Academico.Application.UseCases.Periodo.Common;

namespace Academico.Application.UseCases.Periodo.GetPeriodo;

public class GetPeriodoOutput
{
    public PeriodoModelOuput periodo { get; set; } = new();

    public GetPeriodoOutput from(Domain.Entity.Periodo periodo)
    {
        this.periodo.id = periodo.Id;
        this.periodo.ano = periodo.NR_ANO;
        this.periodo.dataInicio = periodo.DT_INICIO;
        this.periodo.dataFim = periodo.DT_FIM;
        this.periodo.status = periodo.ST_PERIODO;

        return this;
    }
}
