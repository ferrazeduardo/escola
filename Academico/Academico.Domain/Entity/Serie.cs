using System;
using Academico.Domain.SeedWork;

namespace Academico.Domain.Entity;

public class Serie : AggregateRoot
{
    public int NR_SERIE { get; set; }

    public ICollection<(int,string)> unidadesSalas { get; set; } = [];

    public ICollection<SerieUnidadeSala> _serieunidadeSalas { get; set; } = [];

    public void AdicionarSerieUnidadeSala(SerieUnidadeSala serieUnidadeSala)
    {
        _serieunidadeSalas.Add(serieUnidadeSala);
    }

    public void RemoverSerieUnidadeSala(SerieUnidadeSala serieUnidadeSala)
    {
        _serieunidadeSalas.Remove(serieUnidadeSala);
    }

}
