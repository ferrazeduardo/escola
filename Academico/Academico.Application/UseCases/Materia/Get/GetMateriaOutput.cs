using System;
using Academico.Application.UseCases.Materia.Common;
using domain = Academico.Domain.Entity;

namespace Academico.Application.UseCases.Materia.Get;

public class GetMateriaOutput
{
    public MateriaModelOutput materia { get; set; } = new();

    internal GetMateriaOutput From(domain.Materia materia)
    {
       this.materia.id = materia.Id;
       this.materia.descricao = materia.DS_MATERIA;
       this.materia.status = materia.ST_MATERIA;
       return this;
    }
}
