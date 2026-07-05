using System;
using MediatR;

namespace Academico.Application.UseCases.Materia.Create;

public class CreateMateriaInput : IRequest<CreateMateriaOutput>
{
    public string descricao { get; set; }
}
