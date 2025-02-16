using MediatR;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Application.UseCases.RedeUseCase.Obter;

public class ObterRede : IRequestHandler<ObterRedeInput, ObterRedePayload>
{
    private readonly IRedeRepository _redeRepository;

    public ObterRede(IRedeRepository redeRepository)
    {
        _redeRepository = redeRepository;
    }
    
    public  async Task<ObterRedePayload> Handle(ObterRedeInput request, CancellationToken cancellationToken)
    {
        Domain.Entity.Rede rede = await _redeRepository.ObterPorId(request.id);

        ObterRedePayload obterRedePayload = new();
        obterRedePayload.razaoSocial = rede.RZ_SOCIAL;
        obterRedePayload.cnpj = rede.NR_CNPJ;
        
        return obterRedePayload;
    }
}