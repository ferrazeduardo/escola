using Academico.Application.UseCases.Materia.Create;
using Academico.Application.UseCases.Materia.Get;
using Academico.Application.UseCases.Materia.List;
using Academico.Application.UseCases.Materia.UpdateStatus;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academico.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MateriaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMateriaInput request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("get")]
        public async Task<IActionResult> Get([FromBody] GetMateriaInput request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("list")]
        public async Task<IActionResult> List([FromBody] ListMateriaInput request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("update/status")]
        public async Task<IActionResult> Delete([FromBody] UpdateStatusInput request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
