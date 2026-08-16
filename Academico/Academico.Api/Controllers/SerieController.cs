using Academico.Application.UseCases.Serie.AddMateriaRede;
using Academico.Application.UseCases.Serie.BindSeriePeriodoUnidade;
using Academico.Application.UseCases.Serie.Create;
using Academico.Application.UseCases.Serie.Get;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academico.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SerieController : ControllerBase
    {
        private IMediator _mediator;

        public SerieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSerieInput request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("materia-rede")]
        public async Task<IActionResult> AddMateriaRede([FromBody] AddMateriaRedeInput request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("serie-periodo-unidade")]
        public async Task<IActionResult> BindSeriePeriodoUnidade([FromBody] BindSeriePeriodoUnidadeInput request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("get")]
        public async Task<IActionResult> Get([FromBody] GetSerieInput request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
