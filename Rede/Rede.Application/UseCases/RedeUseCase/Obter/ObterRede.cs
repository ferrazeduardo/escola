using MediatR;
using Rede.Domain.DataTransferObject;
using Rede.Domain.Entity;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Application.UseCases.RedeUseCase.Obter;

public class ObterRede : IRequestHandler<ObterRedeInput, ObterRedeOutput>
{
    private readonly IRedeRepository _redeRepository;

    public ObterRede(IRedeRepository redeRepository)
    {
        _redeRepository = redeRepository;
    }
    
    public  async Task<ObterRedeOutput> Handle(ObterRedeInput request, CancellationToken cancellationToken)
    {
        Domain.Entity.Rede rede = await _redeRepository.ObterPorId(request.id);

        ObterRedeOutput obterRedePayload = new();
        obterRedePayload.id = rede.Id;
        obterRedePayload.razaoSocial = rede.RZ_SOCIAL;
        obterRedePayload.cnpj = rede.NR_CNPJ;
        obterRedePayload.Unidades = rede.Unidades?.Select(u => new UnidadeDto
        {
            id = u.Id,
            complemento = u.DS_COMPLMENTO,
            endereco = u.DS_ENDERECO,
            numero = u.NR_UNIDADE,
            cep = u.NR_CEP
        }).ToList();
        obterRedePayload.DiaVencimentos = rede.DiaVencimentos?.Select(d => new DiaVencimentoDto
        {
            dia = d.Dia
        }).ToList();
        
        return obterRedePayload;
    }
}