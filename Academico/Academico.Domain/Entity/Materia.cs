using System;
using Academico.Domain.Exception;
using Academico.Domain.SeedWork;

namespace Academico.Domain.Entity;

public class Materia : AggregateRoot
{

    public Materia(string ds_materia)
    {
        DS_MATERIA = ds_materia;
        Validacao();
    }

    public Materia()
    {
        
    }

    public String DS_MATERIA { get; set; }
    public Boolean ST_MATERIA { get; set; }

    public void Ativar()
    {
        ST_MATERIA = true;
    }

    public void Validacao()
    {
        ExcecaoDeDominio.HaError(string.IsNullOrEmpty(DS_MATERIA), "Descrição da matéria é obrigatório.");
    }
}
