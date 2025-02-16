using MediatR;
using Rede.Domain.Entity;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Application.UseCases.RedeUseCase.Save;

public class SaveRede : IRequestHandler<SaveRedeInput, SaveRedePayload>
{
    private readonly IRedeRepository _redeRepository;

    public SaveRede(IRedeRepository redeRepository)
    {
        _redeRepository = redeRepository;
    }
    
    public async Task<SaveRedePayload> Handle(SaveRedeInput request, CancellationToken cancellationToken)
    {
        var diasVencimento = DiasVencimento(request);
        
        Domain.Entity.Rede rede = new(request.razaoSocial,request.cnpj,request.codigoUsuario,diasVencimento);
        
        await _redeRepository.Inserir(rede);

        SaveRedePayload payload = new();
        payload.codigo = rede.Id;
        
        return payload;
    }

    private static List<DiaVencimento> DiasVencimento(SaveRedeInput request)
    {
        var diasVencimento = request.diasVencimentoRede.Select(dia => new DiaVencimento()
        {
            Dia = dia
        }).ToList();
        return diasVencimento;
    }
}