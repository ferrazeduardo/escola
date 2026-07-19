using System;
using MediatR;

namespace Academico.Application.UseCases.Serie.Create;

public record CreateSerieInput(int numero) : IRequest<CreateSerieOutput>;

