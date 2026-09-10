using MediatR;
using Rede.Domain.Entity;
using Rede.Domain.Exception;
using Rede.Domain.Interfaces;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Application.UseCases.RedeUseCase.AddUnidade;

public class AddUnidade : IRequestHandler<AddUnidadeInput, AddUnidadePayload>
{
    private readonly IRedeRepository _redeRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRedeUnidadeRepository _redeUnidadeRepository;
    private readonly IUnidadeRepository _unidadeRepository;

    public AddUnidade(IRedeRepository redeRepository, IUnitOfWork unitOfWork, IRedeUnidadeRepository redeUnidadeRepository, IUnidadeRepository unidadeRepository)
    {
        _redeRepository = redeRepository;
        _unitOfWork = unitOfWork;
        _redeUnidadeRepository = redeUnidadeRepository;
        _unidadeRepository = unidadeRepository;
    }

    public async Task<AddUnidadePayload> Handle(AddUnidadeInput request, CancellationToken cancellationToken)
    {
        var rede = _redeRepository.ObterPorId(request.id_rede);
        var unidade = _unidadeRepository.ObterPorId(request.id_unidade);

        await Task.WhenAll(rede, unidade);
        NotFounException.IsNull(rede, "Rede não existe");
        NotFounException.IsNull(unidade, "Unidade não existe");

        RedeUnidade redeUnidade = new RedeUnidade();
        redeUnidade.id_rede = request.id_rede;
        redeUnidade.id_unidade = request.id_unidade;


        await _unitOfWork.Commit(cancellationToken);

        AddUnidadePayload output = new();

        return output;
    }


}