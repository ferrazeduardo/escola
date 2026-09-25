using System;
using MediatR;

namespace Academico.Application.UseCases.Turma.Delete;

public class DeleteTurmaInput : IRequest<DeleteTurmaOutput>
{
    public int id { get; set; }
}
