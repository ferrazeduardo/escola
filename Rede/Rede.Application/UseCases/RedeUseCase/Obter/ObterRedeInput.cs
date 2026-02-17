using MediatR;

namespace Rede.Application.UseCases.RedeUseCase.Obter;

public class ObterRedeInput : IRequest<ObterRedePayload>
{
    public int id { get; set; }
}