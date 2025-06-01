package com.ferrazeduardo.escola.Serie.domain;


import java.util.UUID;

public class Materia {

    private UUID id;

    public UUID getId() {
        return id;
    }

    public String getDS_MATERIA() {
        return DS_MATERIA;
    }

    public String getST_MATERIA() {
        return ST_MATERIA;
    }

    private String DS_MATERIA;
    private String ST_MATERIA;

    public Materia(String DS_MATERIA, String ST_MATERIA) {
        this.DS_MATERIA = DS_MATERIA;
        this.ST_MATERIA = ST_MATERIA;
    }
}
