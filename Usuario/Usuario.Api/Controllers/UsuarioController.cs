using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Usuario.Application.UseCases.UsuarioUseCase.Save;

namespace Usuario.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] UsuarioSaveInput usuarioSaveInput)
        {
            var response = await _mediator.Send(usuarioSaveInput);
            return Ok(response);
        }
    }
}
