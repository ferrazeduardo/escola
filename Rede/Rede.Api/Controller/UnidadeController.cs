using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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


    
    }
}
