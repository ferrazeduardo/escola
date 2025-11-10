using System;
using Serie.Domain.Enum;

namespace Serie.Domain.Entity;

public class Aula : SeedWorks.Entity
{

    public Aula(
              String DS_AULA
            , Horario horario
            , Sala sala
            , Materia materia
            , DiaSemana diaSemana) {
        this.horario = horario;
        this.DS_AULA = DS_AULA;
        this.sala = sala;
        this.materia = materia;
        this.diaSemana = diaSemana;
    }

    public Aula(Guid id
            , String DS_AULA
            , Horario horario
            , Sala sala
            , Materia materia
            , DiaSemana diaSemana) {
        this.setId(id);
        this.horario = horario;
        this.DS_AULA = DS_AULA;
        this.sala = sala;
        this.materia = materia;
        this.diaSemana = diaSemana;
    }

    public Aula(){}

    public String DS_AULA{ get; private set; }

    
    public String getDS_AULA() {
        return DS_AULA;
    }



    public Horario getHorario() {
        return horario;
    }

    public Horario horario{ get; private set; }

    public Sala sala{ get; private set; }

    public Sala getSala() {
        return sala;
    }

    public Materia getMateria() {
        return materia;
    }

    public Materia materia { get; private set; }
    public DiaSemana diaSemana{ get; private set; }
    public DiaSemana getDiaSemana() {
        return diaSemana;
    }

}
