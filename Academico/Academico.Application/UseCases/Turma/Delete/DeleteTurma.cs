using System;
using Academico.Domain.Exception;
using Academico.Domain.Interface;
using Academico.Domain.Interface.Repository;
using Academico.Domain.Service;
using MediatR;

namespace Academico.Application.UseCases.Turma.Delete;

public class DeleteTurma : IRequestHandler<DeleteTurmaInput, DeleteTurmaOutput>
{
    private IUnitOfWork _unitOfWork;
    private ITurmaRepository _turmaRepository;
    private IPessoaRepository _pessoaRepository;
    private VerificadorExisteAlunoService _verificadorExisteAlunoService;

    public DeleteTurma(IUnitOfWork unitOfWork, ITurmaRepository turmaRepository, IPessoaRepository pessoaRepository, VerificadorExisteAlunoService verificadorExisteAlunoService)
    {
        _unitOfWork = unitOfWork;
        _turmaRepository = turmaRepository;
        _pessoaRepository = pessoaRepository;
        _verificadorExisteAlunoService = verificadorExisteAlunoService;
    }
    public async Task<DeleteTurmaOutput> Handle(DeleteTurmaInput request, CancellationToken cancellationToken)
    {
        var turmaAsync = _turmaRepository.Get(t => t.Id == request.id);
        var quantidadeHistoricoAsync = _pessoaRepository.Count(p => p.Historicos.Any(h => h.ID_TURMA == request.id));
        await Task.WhenAll(turmaAsync,quantidadeHistoricoAsync);
        
        var turma = await turmaAsync;
        var quantidadeHistorico = await quantidadeHistoricoAsync;
        NotFoundException.IsNull(turma, "Turma não encontrada");

        _verificadorExisteAlunoService.Verificar(quantidadeHistorico);
        await _turmaRepository.Delete(turma, cancellationToken);

        return new DeleteTurmaOutput();
    }
}
