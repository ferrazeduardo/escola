using System;
using System.Net;
using Academico.Application.UseCases.Pessoa.Common;
using MediatR;

namespace Academico.Application.UseCases.Pessoa.LancarNota;

public record LancarNotaInput(List<LancarNotaModelInput> notas) : IRequest<LancarNotaOutput>
{
}
