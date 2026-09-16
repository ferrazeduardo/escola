using System;
using MediatR;

namespace Academico.Application.UseCases.Turma.List;

public record ListTurmaInput(int? unidadeId,int? periodoId) : IRequest<ListTurmaOutput>
{
}
