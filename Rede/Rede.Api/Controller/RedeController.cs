using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rede.Application.UseCases.RedeUseCase.Obter;
using Rede.Application.UseCases.RedeUseCase.Save;

namespace Rede.Api.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class RedeController : ControllerBase
    {
        private IMediator _mediator;

        public RedeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] SaveRedeInput saveRedeInput)
        {
            var response = await _mediator.Send(saveRedeInput);
            return Ok(response);
        }

        [HttpPost("obter")]
        public async Task<IActionResult> Obter([FromBody] ObterRedeInput obterRedeInput)
        {
            var response = await _mediator.Send(obterRedeInput);
            return Ok(response);
        }
    }
}
