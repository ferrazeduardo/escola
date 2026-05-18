using System;
using Academico.Domain.SeedWork;

namespace Academico.Domain.Entity;

public class Serie : AggregateRoot
{
    public int NR_SERIE { get; set; }
}
