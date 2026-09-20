using System;
using MediatR;

namespace Academico.Application.UseCases.Turma.Create;

public class CreateTurmaInput : IRequest<CreateTurmaOutput>
{
    public string sigla { get; internal set; }
    public int periodoId { get; internal set; }
    public int unidadeId { get; internal set; }
    public string numeroSala { get; internal set; }
}
