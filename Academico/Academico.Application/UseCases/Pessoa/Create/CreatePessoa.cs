using System;
using Academico.Domain.Interface;
using Academico.Domain.Interface.Repository;
using app = Academico.Domain.Entity;
using MediatR;

namespace Academico.Application.UseCases.Pessoa.Create;

public class CreatePessoa : IRequestHandler<CreatePessoaInput, CreatePessoaOutput>
{
    private IPessoaRepository _pessoaRepository;
    private IUnitOfWork _unitOfWork;

    public CreatePessoa(IPessoaRepository pessoaRepository, IUnitOfWork unitOfWork)
    {
        _pessoaRepository = pessoaRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreatePessoaOutput> Handle(CreatePessoaInput request, CancellationToken cancellationToken)
    {
        app.Pessoa pessoa = new(request.nome, request.cpf, request.rg, request.dataNascimento);
        var pessoaJaExistente = await _pessoaRepository.Get(p => p.NR_CPF == request.cpf);
        pessoa.JaSalvoBanco(pessoaJaExistente);

        await _pessoaRepository.Cadastrar(pessoa, cancellationToken);

        await _unitOfWork.Commit(cancellationToken);
        return new CreatePessoaOutput()
        {
            id = pessoa.IdGuid
        };
    }
}
