using System;
using MediatR;

namespace Academico.Application.UseCases.Periodo.List;

public class ListPeriodoInput : IRequest<ListPeriodoOutput>
{
    public DateTime anoInicio { get; set; }
    public DateTime anoFim { get; set; }
}
