using System;
using MediatR;
using Rede.Domain.Exception;
using Rede.Domain.Interfaces;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Application.UseCases.RedeUseCase.AddSalaUnidade;

public class AddSalaUnidade : IRequestHandler<AddSalaUnidadeInput, AddSalaUnidadeOutput>
{
    private IRedeRepository _redeRepository;
    private IUnitOfWork _unitOfWork;

    public AddSalaUnidade(IRedeRepository redeRepository,IUnitOfWork unitOfWork)
    {
        _redeRepository = redeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<AddSalaUnidadeOutput> Handle(AddSalaUnidadeInput request, CancellationToken cancellationToken)
    {
        var rede = await _redeRepository.ObterPorId(request.redeId);
        NotFounException.IsNull(rede, "Rede não encontrada");

        rede.GetUnidadeById(request.unidadeId).AddSala(new Domain.Entity.Sala(request.numeroSala, request.quantidade));
        await _unitOfWork.Commit(cancellationToken);
        return new AddSalaUnidadeOutput();
    }
}
