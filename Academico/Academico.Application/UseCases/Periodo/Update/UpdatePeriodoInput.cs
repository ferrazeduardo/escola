using System;
using MediatR;

namespace Academico.Application.UseCases.Periodo.Update;

public class UpdatePeriodoInput : IRequest<UpdatePeriodoOutput>
{
    public int id { get; set; }
    public int ano { get; set; }
    public DateTime dateFim { get; set; }
    public DateTime dateInicio { get; set; }
    public string status { get; set; }
}
