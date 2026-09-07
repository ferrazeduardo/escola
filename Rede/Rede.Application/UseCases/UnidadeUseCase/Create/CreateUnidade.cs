using System;
using MediatR;
using Rede.Domain.Interfaces;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Application.UseCases.UnidadeUseCase.Create;

public class CreateUnidade : IRequestHandler<CreateUnidadeInput, CreateUnidadeOutput>
{
    private IUnidadeRepository _unidadeRepository;
    private IUnitOfWork _unitOfWork;

    public CreateUnidade(IUnitOfWork unitOfWork, IUnidadeRepository unidadeRepository)
    {
        _unidadeRepository = unidadeRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<CreateUnidadeOutput> Handle(CreateUnidadeInput request, CancellationToken cancellationToken)
    {
        Domain.Entity.Unidade unidade = new Domain.Entity.Unidade(
            endereco: request.endereco,
            cep: request.cep,
            numeroUnidade: request.numeroUnidade,
            usuarioRegistro: request.usuarioRegistro,
            dsComplmento: request.complemento
        );

        unidade.AddTelefoneRange(request.telefones);

        await _unidadeRepository.Inserir(unidade, cancellationToken);

        _unitOfWork.Commit(cancellationToken);

        CreateUnidadeOutput output = new();
        output.id = unidade.Id;

        return output;
    }
}
