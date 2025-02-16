using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rede.Application.UseCases.RedeUseCase.Save;

namespace Rede.Api.Redes;

public class Mutation
{
    
    public async Task<SaveRedePayload> SaveRedeAsync([FromBody] SaveRedeInput input, [Service] IMediator _mediator, CancellationToken ctCancellationToken)
    { 
        var response = await _mediator.Send(input, ctCancellationToken);
        return response;
    }
}