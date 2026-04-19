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
        Domain.Entity.Rede rede = new(request.razaoSocial,request.cnpj,request.codigoUsuario);
        
        await _redeRepository.Inserir(rede,cancellationToken);
        await _unitOfWork.Commit(cancellationToken);
        SaveRedePayload payload = new();
        payload.codigo = rede.Id;
        
        return payload;
    }

   
}