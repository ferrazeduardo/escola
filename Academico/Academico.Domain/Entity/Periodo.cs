using System;
using Academico.Domain.SeedWork;
using Academico.Domain.Validator;

namespace Academico.Domain.Entity;

public class Periodo : AggregateRoot
{
    public Periodo(int nR_ANO,DateTime dataInicio, DateTime dataFim)
    {
        NR_ANO = nR_ANO;
        DT_INICIO = dataInicio;
        DT_FIM = dataFim;
        Ativar();
    }

    private void Ativar()
    {
        ST_PERIODO = true;
    }

    public Periodo()
    {
        
    }

    public int NR_ANO { get; set; }
    public bool ST_PERIODO { get; set; }

    public DateTime DT_INICIO { get; set; }
    public DateTime DT_FIM { get; set; }

    public void Update(bool status, DateTime dateFim, DateTime dateInicio)
    {
        ST_PERIODO = status;;
        DT_FIM = dateFim < new DateTime(1900,1,1) ? DT_FIM : dateFim;
        DT_INICIO = dateInicio < new DateTime(1900,1,1) ? DT_INICIO : dateInicio;
    }


    public void Validacao()
    {
        ValidadorDeRegra.Novo()
            .Quando(NR_ANO < 1900, "Ano não pode ser menor que 1900")
            .Quando(DT_FIM < new DateTime(1900,1,1), "Data de fim não pode ser menor que 01/01/1900")
            .Quando(DT_INICIO < new DateTime(1900,1,1), "Data de início não pode ser menor que 01/01/1900")
            .DispararExcecaoSeExistir();
    }
}
