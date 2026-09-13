using System;

namespace Academico.Domain.Entity;

public class Historico : SeedWork.Entity
{
    public Historico(int idAluno, int idTurma)
    {
        ID_ALUNO = idAluno;
        ID_TURMA = idTurma;
    }

    public Historico()
    {

    }

    public int ID_ALUNO {get; private set;}
    public int ID_TURMA {get; private set;}
    public ICollection<Nota> Notas {get; private set;} = [];
    public ICollection<Frequencia> Frequencias {get; private set;} = [];
}
