using System;
using Academico.Domain.SeedWork;

namespace Academico.Domain.Entity;

public class Periodo : AggregateRoot
{
    public int Ano { get; set; }
    public string Status { get; set; }
}
