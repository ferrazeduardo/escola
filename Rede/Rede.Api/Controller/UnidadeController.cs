using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rede.Application.UseCases.UnidadeUseCase.AddUnidade;

namespace Rede.Api.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class UnidadeController : ControllerBase
    {
        private IMediator _mediator;

        public UnidadeController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("vincular")]
        public async Task<IActionResult> AddUnidade([FromBody] AddUnidadeInput addUnidadeInput)
        {
            var response = await _mediator.Send(addUnidadeInput);
            return Ok(response);
        }
    }
}
