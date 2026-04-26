using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Usuario.Application.UseCases.UsuarioUseCase.AddPerfilUsuarioRede;
using Usuario.Application.UseCases.UsuarioUseCase.Listar;
using Usuario.Application.UseCases.UsuarioUseCase.Obter;
using Usuario.Application.UseCases.UsuarioUseCase.Save;
using Usuario.Application.UseCases.UsuarioUseCase.Update;

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

        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] UsuarioSaveInput usuarioSaveInput)
        {
            var response = await _mediator.Send(usuarioSaveInput);
            return Ok(response);
        }


        [HttpPost("obter")]
        public async Task<IActionResult> Obter([FromBody] ObterInput obter)
        {
            var response = await _mediator.Send(obter);
            return Ok(response);
        }

        [HttpPost("listar")]
        public async Task<IActionResult> Listar([FromBody] ListarInput listar)
        {
            var response = await _mediator.Send(listar);
            return Ok(response);
        }


        [HttpPost("vincular/perfil")]
        public async Task<IActionResult> AddPerfilUsuarioRede([FromBody] AddPerfilUsuarioRedeInput addPerfilUsuarioRedeInput)
        {
            var response = await _mediator.Send(addPerfilUsuarioRedeInput);
            return Ok(response);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateUsuarioInput updateUsuarioInput)
        {
            var response = await _mediator.Send(updateUsuarioInput);
            return Ok(response);
        }

    }
}
