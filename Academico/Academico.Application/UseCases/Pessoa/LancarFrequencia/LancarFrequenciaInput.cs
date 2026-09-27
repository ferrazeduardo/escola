using System;
using Academico.Application.UseCases.Pessoa.Common;
using MediatR;

namespace Academico.Application.UseCases.Pessoa.LancarFrequencia;

public record LancarFrequenciaInput(List<LancarFrequenciaModelInput> frequencias) : IRequest<LancarFrequenciaOutput>
{

}
