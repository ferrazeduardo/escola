using System;
using Academico.Domain.Exception;
using Academico.Domain.Interface;
using Academico.Domain.Interface.Repository;
using MediatR;

namespace Academico.Application.UseCases.Pessoa.Matricular;

public class Matricular : IRequestHandler<MatricularInput, MatricularOutput>
{
    private IPessoaRepository _pessoaRepository;
    private ITurmaRepository _turmaRepository;
    private IUnitOfWork _unitOfWork;

    public Matricular(IPessoaRepository pessoaRepository, ITurmaRepository turmaRepository, IUnitOfWork unitOfWork)
    {
        _pessoaRepository = pessoaRepository;
        _turmaRepository = turmaRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<MatricularOutput> Handle(MatricularInput request, CancellationToken cancellationToken)
    {
        var turma = await _turmaRepository.Get(x => x.Id == request.turmaId);
        NotFoundException.IsNull(turma, "Turma não existe");

        var aluno = await _pessoaRepository.Get(x => x.Id == request.alunoId);
        NotFoundException.IsNull(aluno, "Aluno não existe");

        aluno.Matricular(turma.Id);

        await _pessoaRepository.Update(aluno, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

        return new MatricularOutput(aluno.Id, turma.Id);
    }
}
