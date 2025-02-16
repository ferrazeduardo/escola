using MediatR;

namespace Rede.Application.UseCases.RedeUseCase.Obter;

public class ObterRedeInput : IRequest<ObterRedePayload>
{
    public Guid id { get; set; }
}