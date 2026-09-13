using System;
using MediatR;

namespace Academico.Application.UseCases.Turma.Get;

public record GetTurmaInput(int id) : IRequest<GetTurmaOutput>
{
}
