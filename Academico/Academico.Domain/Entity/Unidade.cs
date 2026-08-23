using System;
using Academico.Domain.DataTransferObject;
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

    public Unidade()
    {

    }

    public string DS_UNIDADE { get; set; }
    public List<Sala> Salas { get; set; }

    public void SalaNaoVinculada(string numeroSala)
    {
        ExcecaoDeDominio.HaError(Salas.Any(x => x.NR_SALA == numeroSala), "Sala não vinculada a unidade");
    }

    public Unidade FromRedeDto(UnidadeDto? result)
    {
        Id = result.id;
        Salas = result.salas.Select(s => new Sala(s.numeroSala, s.qtdMaxima)).ToList();
        return this;
    }
}
