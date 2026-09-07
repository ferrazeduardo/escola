using System;
using MediatR;
using Rede.Domain.Exception;
using Rede.Domain.Interfaces;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Application.UseCases.UnidadeUseCase.Update;

public class UpdateUnidade : IRequestHandler<UpdateUnidadeInput, UpdateUnidadeOutput>
{
    private IUnitOfWork _unitOfWork;
    private IUnidadeRepository _unidadeRepository;

    public UpdateUnidade(IUnitOfWork unitOfWork, IUnidadeRepository unidadeRepository)
    {
        _unitOfWork = unitOfWork;
        _unidadeRepository = unidadeRepository;
    }

    public async Task<UpdateUnidadeOutput> Handle(UpdateUnidadeInput request, CancellationToken cancellationToken)
    {
        var unidade = await _unidadeRepository.ObterPorId(request.id, true);
        NotFounException.IsNull(unidade, "Unidade não encontrada");
        unidade.Update(request.endereco, request.cep, request.numero, request.status, request.complemento);
        await _unitOfWork.Commit(cancellationToken);
        return new UpdateUnidadeOutput();
    }
}
