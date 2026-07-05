using System;
using MediatR;

namespace Academico.Application.UseCases.Materia.Get;

public record GetMateriaInput(int id) : IRequest<GetMateriaOutput> ; 
