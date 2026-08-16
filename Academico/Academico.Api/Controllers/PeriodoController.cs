using Academico.Application.UseCases.Periodo.Create;
using Academico.Application.UseCases.Periodo.Delete;
using Academico.Application.UseCases.Periodo.GetPeriodo;
using Academico.Application.UseCases.Periodo.List;
using Academico.Application.UseCases.Periodo.Update;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academico.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PeriodoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PeriodoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePeriodoInput request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("get")]
        public async Task<IActionResult> Get([FromBody] GetPeriodoInput request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("list")]
        public async Task<IActionResult> List([FromBody] ListPeriodoInput request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePeriodoInput request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new DeletePeriodoInput { id = id };
            var result = await _mediator.Send(request);
            return Ok(result);
        }

    }
}
