using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Usuario.Application.UseCases.PerfilUseCase.Get;
using Usuario.Application.UseCases.PerfilUseCase.Listar;
using Usuario.Application.UseCases.PerfilUseCase.Save;

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

        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] PerfilSaveInput perfilSaveInput)
        {
            var response = await _mediator.Send(perfilSaveInput);
            return Ok(response);
        }

        [HttpPost("list")]
        public async Task<IActionResult> ListarTodos()
        {
            var response = await _mediator.Send(new ListarPerfilInput());
            return Ok(response);
        }
        [HttpPost("get")]
        public async Task<IActionResult> Get([FromQuery] GetPerfilInput getPerfilInput)
        {
            var response = await _mediator.Send(getPerfilInput);
            return Ok(response);
        }
    }
}
