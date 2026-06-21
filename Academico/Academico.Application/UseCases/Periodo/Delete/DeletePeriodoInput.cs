using System;
using MediatR;

namespace Academico.Application.UseCases.Periodo.Delete;

public class DeletePeriodoInput : IRequest<DeletePeriodoOutput>
{
    public int id { get; set; }
}
