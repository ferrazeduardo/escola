using System;
using Academico.Application.UseCases.Periodo.Common;

namespace Academico.Application.UseCases.Periodo.List;

public class ListPeriodoOutput
{
    public List<PeriodoModelOuput> periodos { get; set; } = [];
}
