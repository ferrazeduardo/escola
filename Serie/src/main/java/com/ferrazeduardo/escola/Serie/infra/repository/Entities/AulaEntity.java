package com.ferrazeduardo.escola.Serie.infra.repository.Entities;

import com.ferrazeduardo.escola.Serie.domain.Enum.DiaSemana;

import java.util.UUID;

public class AulaEntity {
    public AulaEntity(UUID id,
            String DS_AULA
            , HorarioEntity horario
            , SalaEntity sala
            , MateriaEntity materia
            , DiaSemana diaSemana) {
        this.Id =  id;
        this.horario = horario;
        this.DS_AULA = DS_AULA;
        this.sala = sala;
        this.materia = materia;
        this.diaSemana = diaSemana;
    }

    public AulaEntity(){}

    private UUID Id;
    private String DS_AULA;

    public UUID getId() {
        return Id;
    }

    public String getDS_AULA() {
        return DS_AULA;
    }



    public HorarioEntity getHorario() {
        return horario;
    }

    private HorarioEntity horario;

    private SalaEntity sala;

    public SalaEntity getSala() {
        return sala;
    }

    public MateriaEntity getMateria() {
        return materia;
    }

    private MateriaEntity materia;
    private DiaSemana diaSemana;
    public DiaSemana getDiaSemana() {
        return diaSemana;
    }

}
