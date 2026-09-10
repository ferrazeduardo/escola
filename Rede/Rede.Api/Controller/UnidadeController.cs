using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rede.Application.UseCases.UnidadeUseCase.Create;
using Rede.Application.UseCases.UnidadeUseCase.Get;
using Rede.Application.UseCases.UnidadeUseCase.List;
using Rede.Application.UseCases.UnidadeUseCase.Update;

namespace Rede.Api.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class UnidadeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UnidadeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUnidadeInput input, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(input, cancellationToken);
            return Ok(result);
        }

    
        [HttpPost("obter")]
        public async Task<IActionResult> Get([FromQuery] GetUnidadeInput input, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(input, cancellationToken);
            return Ok(result);
        }   

        [HttpPost("listar")]
        public async Task<IActionResult> List([FromBody] ListUnidadeInput input, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(input, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUnidadeInput input, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(input, cancellationToken);
            return Ok(result);
        }
    }
}
