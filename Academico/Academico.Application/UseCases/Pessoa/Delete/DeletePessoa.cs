using System;
using Academico.Domain.Exception;
using Academico.Domain.Interface;
using Academico.Domain.Interface.Repository;
using MediatR;

namespace Academico.Application.UseCases.Pessoa.Delete;

public class DeletePessoa : IRequestHandler<DeletePessoaInput, DeletePessoaOutput>
{
    private IPessoaRepository _pessoaRepository;
    private IUnitOfWork _unitOfWork;

    public DeletePessoa(IPessoaRepository pessoaRepository, IUnitOfWork unitOfWork)
    {
        _pessoaRepository = pessoaRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<DeletePessoaOutput> Handle(DeletePessoaInput request, CancellationToken cancellationToken)
    {
        var pessoa = await _pessoaRepository.Get(x => x.Id == request.id);
        NotFoundException.IsNull(pessoa, "Pessoa não encontrada.");

        await _pessoaRepository.Delete(pessoa, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

        return new DeletePessoaOutput();
    }
}
