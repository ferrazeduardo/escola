using MediatR;
using Rede.Domain.Entity;
using Rede.Domain.Interfaces;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Application.UseCases.RedeUseCase.Save;

public class SaveRede : IRequestHandler<SaveRedeInput, SaveRedePayload>
{
    private readonly IRedeRepository _redeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SaveRede(IRedeRepository redeRepository,IUnitOfWork unitOfWork)
    {
        _redeRepository = redeRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<SaveRedePayload> Handle(SaveRedeInput request, CancellationToken cancellationToken)
    {
        var diasVencimento = DiasVencimento(request);
        
        Domain.Entity.Rede rede = new(request.razaoSocial,request.cnpj,request.codigoUsuario,diasVencimento);
        
        await _redeRepository.Inserir(rede,cancellationToken);
        _unitOfWork.Commit(cancellationToken);
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