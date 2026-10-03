using Academico.Application.UseCases.Pessoa.Create;
using Academico.Application.UseCases.Pessoa.Get;
using Academico.Application.UseCases.Pessoa.List;
using Academico.Application.UseCases.Pessoa.Transferencia;
using Academico.Application.UseCases.Pessoa.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Academico.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private IMediator _mediator;

        public PessoaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] CreatePessoaInput createPessoaInput)
        {
            var response = await _mediator.Send(createPessoaInput);
            return Ok(response);
        }

        [HttpPost("get")]
        public async Task<IActionResult> Get([FromBody] GetPessoaInput getPessoaInput)
        {
            var response = await _mediator.Send(getPessoaInput);
            return Ok(response);
        }

        [HttpPost("list")]
        public async Task<IActionResult> List([FromBody] ListPessoaInput listPessoaInput)
        {
            var response = await _mediator.Send(listPessoaInput);
            return Ok(response);
        }
        
        [HttpPut("transferencia")]
        public async Task<IActionResult> Transferencia([FromBody] TransferenciaInput transferenciaInput)
        {
            var response = await _mediator.Send(transferenciaInput);
            return Ok(response);
        }   

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePessoaInput updatePessoaInput)
        {
            var response = await _mediator.Send(updatePessoaInput);
            return Ok(response);
        }
    }
}
