using System;
using Academico.Domain.Exception;

namespace Academico.Domain.Service;

public class VerificadorExisteAlunoService
{
    public void Verificar(int quantidadeAlunosMatriculados)
    {
        ExcecaoDeDominio.HaError(quantidadeAlunosMatriculados > 0, "Turma não pode ser excluida, pois existem alunos matriculados nela");
    }
}
