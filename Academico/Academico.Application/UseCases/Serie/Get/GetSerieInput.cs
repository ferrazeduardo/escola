using System;
using MediatR;

namespace Academico.Application.UseCases.Serie.Get;

public record GetSerieInput(int id, int unidadeId, int redeId) : IRequest<GetSerieOutput>;