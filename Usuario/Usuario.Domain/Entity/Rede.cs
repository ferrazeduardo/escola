using System;

namespace Usuario.Domain.Entity;

public class Rede : SeedWork.Entity
{
    public string DS_REDE { get; set;}

    public ICollection<Unidade> Unidades { get; private set; }
}
