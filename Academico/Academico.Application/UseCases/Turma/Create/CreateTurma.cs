using System;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Academico.Domain.Exception;
using domain = Academico.Domain.Entity;
using Academico.Domain.Interface;
using Academico.Domain.Interface.Repository;
using MediatR;

namespace Academico.Application.UseCases.Turma.Create;

public class CreateTurma : IRequestHandler<CreateTurmaInput, CreateTurmaOutput>
{
    private IUnitOfWork _unitOfWork;
    private ITurmaRepository _turmaRepository;

    public CreateTurma(IUnitOfWork unitOfWork, ITurmaRepository turmaRepository)
    {
        _unitOfWork = unitOfWork;
        _turmaRepository = turmaRepository;
    }
    public async Task<CreateTurmaOutput> Handle(CreateTurmaInput request, CancellationToken cancellationToken)
    {
        var turma = await _turmaRepository.Get(x => x.ID_PERIODO == request.periodoId && x.ID_UNIDADE == request.unidadeId && x.NR_SALA == request.numeroSala && x.SG_TURMA == request.sigla);
        AlreadyExistsException.IsNotNull("Turma", turma, JsonSerializer.Serialize(request));

        domain.Turma turmaCreate = new(request.sigla, request.periodoId, request.unidadeId, request.numeroSala);
        await _turmaRepository.Cadastrar(turma, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

        return new CreateTurmaOutput(){id = turmaCreate.Id};
    }
}
