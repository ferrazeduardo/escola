using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rede.Application.UseCases.RedeUseCase.Save;

namespace Rede.Api.Redes;

public class RedesMutation
{
    public async Task<SaveRedeOutput> SaveRedeAsync([FromBody] SaveRedeCommand saveRedeCommand, [Service] IMediator _mediator,
        CancellationToken cancellationToken)
    {
        var output = await _mediator.Send(saveRedeCommand, cancellationToken);
        return output;
    }
}