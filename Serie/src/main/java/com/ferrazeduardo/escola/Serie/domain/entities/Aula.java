package com.ferrazeduardo.escola.Serie.domain.entities;

import java.util.UUID;

public class Aula {
    public Aula(UUID id
            , String DS_AULA
            , Horario horario
            , Sala sala
            , Serie serie) {
        Id = id;
        this.horario = horario;
        this.DS_AULA = DS_AULA;
        this.sala = sala;
        this.serie = serie;
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

    public Serie getSerie() {
        return serie;
    }

    private Serie serie;
}
