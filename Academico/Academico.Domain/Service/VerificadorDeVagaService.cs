using System;
using System.Linq;
using Academico.Domain.Entity;
using Academico.Domain.Exception;

namespace Academico.Domain.Service;

public class VerificadorDeVagaService
{
    public void Verificar(Turma turma, Unidade unidade, int qtdAlunosMatriculados)
    {
        var sala = unidade.Salas.FirstOrDefault(x => x.NR_SALA == turma.NR_SALA);
        NotFoundException.IsNull(sala, "Sala não vinculada a unidade");

        ExcecaoDeDominio.HaError(qtdAlunosMatriculados >= sala.QT_MAXIMA, "Não há vaga disponível nessa turma");
    }
}
