using System;
using Academico.Domain.SeedWork;

namespace Academico.Domain.Entity;

public class Serie : AggregateRoot
{
    public int NR_SERIE { get; private set; }

    public ICollection<int> materiasId { get; private set; } = [];
    public int redeId { get; private set; }
    public ICollection<SerieMateriaRede> SerieMateriaRede { get; private set; } = [];


    public int periodosId { get; private set; }
    public int unidadeId { get; private set; }
    public string nrSala { get; private set; }
    public SeriePeriodoUnidade SeriePeriodoUnidade { get; private set; } = new();
}
