using MediatR;
using Rede.Application.UseCases.RedeUseCase.Obter;

namespace Rede.Api.Redes;

public class Query
{
    public string Hello(string name = "World") => $"Hello {name}";

    public async Task<ObterRedePayload> GetRedeAsync(int id, [Service] IMediator _mediator,
        CancellationToken cancellationToken)
    {
        var output = await _mediator.Send(new ObterRedeInput { id = id }, cancellationToken);
        return output;
    }
}