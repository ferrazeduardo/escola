using System;
using Academico.Domain.SeedWork;

namespace Academico.Domain.Entity;

public class Turma : AggregateRoot
{
    public string SG_TURMA { get; set; }
    public int periodosId { get; private set; }
    public int unidadeId { get; private set; }
    public string nrSala { get; private set; }
}
