using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("listar/todos")]
        public async Task<IActionResult> ListarTodos()
        {
            var response = await _mediator.Send(new ListarPerfilInput());
            return Ok(response);
        }
    }
}
