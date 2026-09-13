using System;

namespace Academico.Application.UseCases.Turma.Common;

public class ModelTurmaOutput
{

    public ModelTurmaOutput(Domain.Entity.Turma turma, Domain.Entity.Periodo periodo)
    {
        Id = turma.Id;
        sigla = turma.SG_TURMA;
        nrSala = turma.NR_SALA;
        ano = periodo.NR_ANO;
    }
    public int Id { get; set; }
    public string sigla { get; set; }
    public string nrSala { get; set; }
    public int ano { get; set; }
}
