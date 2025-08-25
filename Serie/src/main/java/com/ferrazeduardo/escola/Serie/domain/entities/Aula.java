package com.ferrazeduardo.escola.Serie.domain.entities;

import com.ferrazeduardo.escola.Serie.domain.Enum.DiaSemana;

import java.util.UUID;

public class Aula {
    public Aula(
              String DS_AULA
            , Horario horario
            , Sala sala
            , Materia materia
            , DiaSemana diaSemana) {
        Id =  UUID.randomUUID();
        this.horario = horario;
        this.DS_AULA = DS_AULA;
        this.sala = sala;
        this.materia = materia;
        this.diaSemana = diaSemana;
    }

    public Aula(){}

    private UUID Id;
    private String DS_AULA;

    public UUID getId() {
        return Id;
    }

    public String getDS_AULA() {
        return DS_AULA;
    }



    public Horario getHorario() {
        return horario;
    }

    private Horario horario;

    private Sala sala;

    public Sala getSala() {
        return sala;
    }

    public Materia getMateria() {
        return materia;
    }

    private Materia materia;
    private DiaSemana diaSemana;
    public DiaSemana getDiaSemana() {
        return diaSemana;
    }

}
