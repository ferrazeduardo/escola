using System;

namespace Academico.Application.UseCases.Periodo.Common;

public class PeriodoModelOuput
{
    public int id { get; set; }
    public int ano { get; set; }
    public DateTime dataInicio { get; set; }
    public DateTime dataFim { get; set; }
    public string status { get; set; }
}
