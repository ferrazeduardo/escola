using System;
using Academico.Application.UseCases.Turma.Common;

namespace Academico.Application.UseCases.Turma.List;

public class ListTurmaOutput
{
    public List<ModelTurmaOutput> turmas { get; set; }

    internal void From(List<Domain.Entity.Turma> turmas)
    {
        throw new NotImplementedException();
    }
}
