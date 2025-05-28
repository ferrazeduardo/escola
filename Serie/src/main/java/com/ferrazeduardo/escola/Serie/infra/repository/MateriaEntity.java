package com.ferrazeduardo.escola.Serie.infra.repository;

import jakarta.persistence.Entity;
import jakarta.persistence.Table;

import java.util.UUID;

@Entity
@Table(name = "materia")
public class MateriaEntity {
    @Id
    private UUID Id;

    public UUID getId() {
        return Id;
    }

    public String getDS_MATERIA() {
        return DS_MATERIA;
    }

    public String getST_MATERIA() {
        return ST_MATERIA;
    }

    private String DS_MATERIA;
    private String ST_MATERIA;

    public MateriaEntity(String DS_MATERIA, String ST_MATERIA) {
        this.DS_MATERIA = DS_MATERIA;
        this.ST_MATERIA = ST_MATERIA;
        this.Id  = UUID.randomUUID();
    }

    public MateriaEntity(){

    }
}
