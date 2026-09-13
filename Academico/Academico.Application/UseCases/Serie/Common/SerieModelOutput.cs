using System;
using domain = Academico.Domain.Entity;
namespace Academico.Application.UseCases.Serie.Common;

public class SerieModelOutput
{
    public SerieModelOutput(int id, int numero, List<domain.Materia> materias)
    {
        this.id = id;
        this.numero = numero;
        this.materias = materias?.Select(m => new MateriaSerieOutput(m.Id,m.DS_MATERIA)).ToList() ?? null; 
    }

    public int id { get; private set; }
    public int numero { get; private set; }
    public List<MateriaSerieOutput> materias { get; private set; } = [];
}

public record MateriaSerieOutput(int id, string nome);



