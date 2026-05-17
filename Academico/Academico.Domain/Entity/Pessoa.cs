using System;
using Academico.Domain.SeedWork;

namespace Academico.Domain.Entity;

public class Pessoa : AggregateRoot
{
    public string Nome { get; set; }
    public string NR_CPF { get; set; }
    public string NR_RG { get; set; }
    public DateTime DH_CREATE { get; set; }
    public DateTime DH_NASCIMENTO { get; set; }

    public ICollection<Responsavel> Responsaveis { get; private set; } = [];

    public void AddResponsavel(Responsavel responsavel)
    {
        Responsaveis.Add(responsavel);
    }

    public void RemoveResponsavel(Responsavel responsavel)
    {
        Responsaveis.Remove(responsavel);
    }
}
