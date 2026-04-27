using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Usuario.Application.UseCases.AuthenticationUseCase.Login;

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
    }
}
