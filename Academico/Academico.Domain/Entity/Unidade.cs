using System;
using Academico.Domain.Exception;
using Academico.Domain.SeedWork;

namespace Academico.Domain.Entity;

public class Unidade : AggregateRoot
{
    public Unidade(string dS_UNIDADE, List<Sala> salas)
    {
        DS_UNIDADE = dS_UNIDADE;
        Salas = salas;
    }

    public string DS_UNIDADE { get; set; }
    public List<Sala> Salas { get; set; }

    public void SalaNaoVinculada(string numeroSala)
    {
        ExcecaoDeDominio.HaError(Salas.Any(x => x.NR_SALA == numeroSala), "Sala não vinculada a unidade");
    }
}
