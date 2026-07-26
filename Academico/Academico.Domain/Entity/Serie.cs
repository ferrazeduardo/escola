using System;
using Academico.Domain.Exception;
using Academico.Domain.SeedWork;

namespace Academico.Domain.Entity;

public class Serie : AggregateRoot
{
    public Serie(int nR_SERIE)
    {
        NR_SERIE = nR_SERIE;
        Validacao();
        Ativar();
    }

    public int NR_SERIE { get; private set; }
    public bool ST_SERIE { get; set; }
    public ICollection<int> materiasId { get; private set; } = [];
    public int redeId { get; private set; }
    public ICollection<SerieMateriaRede> SerieMateriaRede { get; private set; } = [];


    public int periodosId { get; private set; }
    public int unidadeId { get; private set; }
    public string nrSala { get; private set; }
    public SeriePeriodoUnidade SeriePeriodoUnidade { get; private set; } = new();

    public void Ativar()
    {
        ST_SERIE = true;
    }

    public void Validacao()
    {
        ExcecaoDeDominio.HaError(NR_SERIE <= 0, "Numéro de série não pode ser zero ou negativo");
    }

    public void VerificaSeMateriaJaExiste(List<int> materiaId)
    {
        var materiasJaVinculadas = materiasId.Where(x => materiaId.Any(y => y == x)).ToList();
        ExcecaoDeDominio.HaError(materiasJaVinculadas.Count > 0, "Matéria já vinculada à série: " + string.Join(",",materiasJaVinculadas));
    }
}
