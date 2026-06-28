using System;
using Academico.Domain.SeedWork;

namespace Academico.Domain.Entity;

public class Serie : AggregateRoot
{
    public int NR_SERIE { get; private set; }

    public ICollection<int> materiasId { get; private set; } = [];
    public ICollection<SerieMateria> _serieMaterias { get; private set; } = [];

    public ICollection<int> periodosId { get; private set; } = [];

    public ICollection<SeriePeriodo> _seriePeriodos { get; private set; } = [];
    public ICollection<(int, string)> unidadesIdSalas { get; private set; } = [];

    public ICollection<SerieUnidadeSala> _serieunidadeSalas { get; private set; } = [];

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
