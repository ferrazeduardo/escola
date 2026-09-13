using System;
using Academico.Domain.SeedWork;

namespace Academico.Domain.Entity;

public class Turma : AggregateRoot
{
    public Turma(string sgTurma, int idPeriodo, int idUnidade, string nrSala)
    {
        SG_TURMA = sgTurma;
        ID_PERIODO = idPeriodo;
        ID_UNIDADE = idUnidade;
        NR_SALA = nrSala;
    }

    public string SG_TURMA { get; private set; }
    public int ID_PERIODO { get; private set; }
    public int ID_UNIDADE { get; private set; }
    public string NR_SALA { get; private set; }
}
