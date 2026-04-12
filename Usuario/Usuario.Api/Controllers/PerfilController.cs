using MediatR;
using Microsoft.AspNetCore.Mvc;
using Usuario.Application.UseCases.PerfilUseCase.Create;
using Usuario.Application.UseCases.PerfilUseCase.Get;
using Usuario.Application.UseCases.PerfilUseCase.List;
using Usuario.Application.UseCases.PerfilUseCase.Update;

namespace Usuario.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private IMediator _mediator;

        public PerfilController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreatePerfilInput createPerfilInput,CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(createPerfilInput, cancellationToken);
            return Ok(response);
        }

        [HttpPost("list")]
        public async Task<IActionResult> ListarTodos(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ListPerfilInput(), cancellationToken);
            return Ok(response);
        }
        [HttpPost("get")]
        public async Task<IActionResult> Get([FromQuery] GetPerfilInput getPerfilInput, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(getPerfilInput, cancellationToken);
            return Ok(response);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdatePerfilInput updatePerfilInput, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(updatePerfilInput, cancellationToken);
            return Ok(response);
        }
    }
}
