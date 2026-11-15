using System;
using MediatR;
using Rede.Domain.Exception;
using Rede.Domain.Interfaces;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Application.UseCases.RedeUseCase.AddSalaUnidade;

public class AddSalaUnidade : IRequestHandler<AddSalaUnidadeInput, AddSalaUnidadeOutput>
{
    private IUnidadeRepository _unidadeRepository;
    private IUnitOfWork _unitOfWork;

    public AddSalaUnidade(IUnidadeRepository unidadeRepository,IUnitOfWork unitOfWork)
    {
        _unidadeRepository = unidadeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<AddSalaUnidadeOutput> Handle(AddSalaUnidadeInput request, CancellationToken cancellationToken)
    {
        var unidade = await _unidadeRepository.ObterPorId(request.unidadeId);
        NotFounException.IsNull(unidade, "Unidade não encontrada");

        unidade.AddSala(new Domain.Entity.Sala(request.numeroSala, request.quantidade));
        await _unitOfWork.Commit(cancellationToken);
        return new AddSalaUnidadeOutput();
    }
}
