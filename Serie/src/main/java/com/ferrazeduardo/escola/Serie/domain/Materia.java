package com.ferrazeduardo.escola.Serie.domain;

import jakarta.persistence.Column;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;

import java.util.UUID;

public class Materia {
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

    @Column(nullable = false,length = 50,unique = true)
    private String DS_MATERIA;
    @Column(nullable = false,length = 1)
    private String ST_MATERIA;

    public Materia(String DS_MATERIA, String ST_MATERIA) {
        this.DS_MATERIA = DS_MATERIA;
        this.ST_MATERIA = ST_MATERIA;
        this.Id  = UUID.randomUUID();
    }
    @ManyToOne
    @JoinColumn(name = "ID_SERIE", nullable = false)
    private Serie serie;
}
