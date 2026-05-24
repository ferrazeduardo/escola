using System;
using Academico.Domain.Exception;
using Academico.Domain.Interface;
using Academico.Domain.Interface.Repository;
using MediatR;

namespace Academico.Application.UseCases.Pessoa.Update;

public class UpdatePessoa : IRequestHandler<UpdatePessoaInput, UpdatePessoaOutput>
{
    private IPessoaRepository _pessoaRepository;
    private IUnitOfWork _unitOfWork;

    public UpdatePessoa(IPessoaRepository pessoaRepository, IUnitOfWork unitOfWork)
    {
        _pessoaRepository = pessoaRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<UpdatePessoaOutput> Handle(UpdatePessoaInput request, CancellationToken cancellationToken)
    {
        var pessoa = await _pessoaRepository.Get(x => x.IdGuid == request.id);
       
        NotFoundException.IsNull(pessoa, "Pessoa não encontrada");
        pessoa.Update(request.cpf, request.nome, request.rg);

        await _unitOfWork.Commit(cancellationToken);

        return new UpdatePessoaOutput();
    }
}
