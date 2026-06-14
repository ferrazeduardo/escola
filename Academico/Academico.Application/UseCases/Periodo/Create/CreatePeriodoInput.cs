using System;
using MediatR;

namespace Academico.Application.UseCases.Periodo.Create;

public class CreatePeriodoInput : IRequest<CreatePeriodoOutput>
{
    public int ano { get; set; }
}
