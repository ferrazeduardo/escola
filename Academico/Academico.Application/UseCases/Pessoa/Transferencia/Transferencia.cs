using System;
using Academico.Domain.Exception;
using Academico.Domain.Interface;
using Academico.Domain.Interface.Repository;
using MediatR;

namespace Academico.Application.UseCases.Pessoa.Transferencia;

public class Transferencia : IRequestHandler<TransferenciaInput, TransferenciaOutput>
{
    private IUnitOfWork _unitOfWork;
    private IPessoaRepository _pessoaRepository;

    public Transferencia(IUnitOfWork unitOfWork, IPessoaRepository pessoaRepository)
    {
        _unitOfWork = unitOfWork;
        _pessoaRepository  = pessoaRepository;
    }
    public  async Task<TransferenciaOutput> Handle(TransferenciaInput request, CancellationToken cancellationToken)
    {
        var pessoa = await _pessoaRepository.Get(x => x.Id == request.pessoaId);
        NotFoundException.IsNull(pessoa, "Pessoa não encontrada");

        pessoa.TransferirTurma(request.historicoId, request.turmaNovaId);
        await _unitOfWork.Commit(cancellationToken);

        return new TransferenciaOutput();
    }
}
