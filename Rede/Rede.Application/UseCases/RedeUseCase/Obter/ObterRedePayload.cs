using Rede.Domain.DataTransferObject;
using Rede.Domain.Entity;

namespace Rede.Application.UseCases.RedeUseCase.Obter;

public class ObterRedePayload
{
    public ObterRedePayload()
    {
        rede = new();
    }
    public RedeDto rede { get; set; }
   
}