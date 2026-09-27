using System;

namespace Academico.Domain.Entity;

public class Nota : SeedWork.Entity 
{
    public Decimal VL_NOTA { get; set; }
    public int ID_HISTORICO { get; set; }
}
