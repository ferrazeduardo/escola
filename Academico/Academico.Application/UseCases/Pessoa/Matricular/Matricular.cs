using System;
using Academico.Domain.Exception;
using Academico.Domain.Interface;
using Academico.Domain.Interface.HttpClients;
using Academico.Domain.Interface.Repository;
using Academico.Domain.Service;
using MediatR;

namespace Academico.Application.UseCases.Pessoa.Matricular;

public class Matricular : IRequestHandler<MatricularInput, MatricularOutput>
{
    private IPessoaRepository _pessoaRepository;
    private ITurmaRepository _turmaRepository;
    private IUnitOfWork _unitOfWork;
    private IUnidadeClient _unidadeClient;
    private VerificadorDeVagaService _verificadorDeVagaService;

    public Matricular(IPessoaRepository pessoaRepository, ITurmaRepository turmaRepository, IUnitOfWork unitOfWork, IUnidadeClient unidadeClient, VerificadorDeVagaService verificadorDeVagaService)
    {
        _pessoaRepository = pessoaRepository;
        _turmaRepository = turmaRepository;
        _unitOfWork = unitOfWork;
        _unidadeClient = unidadeClient;
        _verificadorDeVagaService = verificadorDeVagaService;
    }

    public async Task<MatricularOutput> Handle(MatricularInput request, CancellationToken cancellationToken)
    {

        await _unitOfWork.BeginTransaction(cancellationToken);
        try
        {

            var turma = await _turmaRepository.GetComLock(request.turmaId, cancellationToken);
            NotFoundException.IsNull(turma, "Turma não existe");

            var unidade = await _unidadeClient.Obter(turma.ID_UNIDADE);
            NotFoundException.IsNull(unidade, "Unidade não existe");

            var aluno = await _pessoaRepository.Get(x => x.Id == request.alunoId);
            NotFoundException.IsNull(aluno, "Aluno não existe");

            var qtdAlunosMatriculados = await _pessoaRepository.Count(x => x.Historicos.Any(h => h.ID_TURMA == turma.Id));

            _verificadorDeVagaService.Verificar(turma, unidade, qtdAlunosMatriculados);

            aluno.Matricular(turma.Id);

            await _pessoaRepository.Update(aluno, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);
            await _unitOfWork.CommitTransaction(cancellationToken);
            return new MatricularOutput(aluno.Id, turma.Id);
        }
        catch
        {
            await _unitOfWork.RollbackTransaction(cancellationToken);
            throw;
        }

    }
}
