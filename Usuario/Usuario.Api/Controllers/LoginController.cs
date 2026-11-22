using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Usuario.Application.UseCases.AuthenticationUseCase.Login;
using Usuario.Application.UseCases.UsuarioUseCase.Save;

namespace Usuario.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginInput loginInput)
        {
            var response = await _mediator.Send(loginInput);
            return Ok(response);
        }

           [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] UsuarioSaveInput usuarioSaveInput)
        {
            var response = await _mediator.Send(usuarioSaveInput);
            return Ok(response);
        }

    }
}
