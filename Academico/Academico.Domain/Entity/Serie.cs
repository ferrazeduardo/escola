using System;
using Academico.Domain.SeedWork;

namespace Academico.Domain.Entity;

public class Serie : AggregateRoot
{
    public int NR_SERIE { get; set; }

    public ICollection<int> periodosId { get; set; } = [];

    public ICollection<SeriePeriodo> _seriePeriodos { get; set; } = [];
    public ICollection<(int, string)> unidadesIdSalas { get; set; } = [];

    public ICollection<SerieUnidadeSala> _serieunidadeSalas { get; set; } = [];

    public void AdicionarPeriodo(int idPeriodo)
    {
        if (!periodosId.Contains(idPeriodo))
            periodosId.Add(idPeriodo);
    }

    public void AdicionarUnidadeSala(int idUnidade, string nrSala)
    {
        if (!unidadesIdSalas.Any(x => x.Item1 == idUnidade && x.Item2 == nrSala))
            unidadesIdSalas.Add((idUnidade, nrSala));
    }


    public void RemoverPeriodo(int idPeriodo)
    {
        if (periodosId.Contains(idPeriodo))
            periodosId.Remove(idPeriodo);
    }

    public void RemoverUnidadeSala(int idUnidade, string nrSala)
    {
        var item = unidadesIdSalas.FirstOrDefault(x => x.Item1 == idUnidade && x.Item2 == nrSala);
        if (item != default)
            unidadesIdSalas.Remove(item);
    }
}
