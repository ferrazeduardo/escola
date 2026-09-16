using System;
using Academico.Domain.Interface.Repository;
using domain = Academico.Domain.Entity;
using MediatR;
using Academico.Domain.Exception;

namespace Academico.Application.UseCases.Turma.List;

public class ListTurma : IRequestHandler<ListTurmaInput, ListTurmaOutput>
{
    private ITurmaRepository _turmaRepository;

    public ListTurma(ITurmaRepository turmaRepository)
    {
        _turmaRepository = turmaRepository;
    }
    public async Task<ListTurmaOutput> Handle(ListTurmaInput request, CancellationToken cancellationToken)
    {
        

        List<domain.Turma> turmas = await _turmaRepository.List(x => 
            (!request.unidadeId.HasValue || x.ID_UNIDADE == request.unidadeId) &&
            (!request.periodoId.HasValue || x.ID_PERIODO == request.periodoId));
        NotFoundException.CountZero(turmas, "Turmas não encontradas");
        var output = new ListTurmaOutput();
        output.From(turmas);
        return output;
    }
}
