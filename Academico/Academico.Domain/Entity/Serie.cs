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

}
