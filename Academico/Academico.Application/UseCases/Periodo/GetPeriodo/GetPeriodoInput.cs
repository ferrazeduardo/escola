using System;
using MediatR;

namespace Academico.Application.UseCases.Periodo.GetPeriodo;

public class GetPeriodoInput : IRequest<GetPeriodoOutput>
{
    internal int ano;

    public int id { get; set; }
}
