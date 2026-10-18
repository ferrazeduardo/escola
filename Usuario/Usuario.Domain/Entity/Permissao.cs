using System;
using Usuario.Domain.SeedWork;

namespace Usuario.Domain.Entity;

public class Permissao : AggregationRoot
{
    public string PL_PERMISSAO { get; set; }
    public string DS_PERMISSAO { get; set; }
    public string DS_MODULO { get; set; }
}
