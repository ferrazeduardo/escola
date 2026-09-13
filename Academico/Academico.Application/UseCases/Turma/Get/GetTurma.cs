using System;
using Academico.Application.UseCases.Turma.Common;
using Academico.Domain.Exception;
using Academico.Domain.Interface.Repository;
using MediatR;

namespace Academico.Application.UseCases.Turma.Get;

public class GetTurma : IRequestHandler<GetTurmaInput, GetTurmaOutput>
{
    private ITurmaRepository _turmaRepository;
    private IPeriodoRepository _periodoRepository;

    public GetTurma(ITurmaRepository turmaRepository, IPeriodoRepository periodoRepository)
    {
        _turmaRepository = turmaRepository;
        _periodoRepository = periodoRepository;
    }
    public  async Task<GetTurmaOutput> Handle(GetTurmaInput request, CancellationToken cancellationToken)
    {
        var turma = await _turmaRepository.Get(x => x.Id == request.id);
        NotFoundException.IsNull(turma, "Turma não encontrada");

        var periodo = await _periodoRepository.Get(x => x.Id == turma.ID_PERIODO);
        NotFoundException.IsNull(periodo, "Período não encontrado");

        ModelTurmaOutput modelTurmaOutput = new ModelTurmaOutput(turma, periodo);

        return new GetTurmaOutput { turma = modelTurmaOutput };
    }
}
