using System;
using MediatR;

namespace Academico.Application.UseCases.Pessoa.Transferencia;

public record TransferenciaInput(int pessoaId,int historicoId, int turmaNovaId) : IRequest<TransferenciaOutput>
{

}
