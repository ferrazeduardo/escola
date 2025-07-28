package com.ferrazeduardo.escola.Serie.infra.repository.Entities;

import jakarta.persistence.*;

import java.io.Serializable;
import java.util.UUID;

@Entity
@Table(name = "materia")
public class MateriaEntity implements Serializable {
    @Id
    @GeneratedValue(strategy = GenerationType.UUID)
    private UUID id;  // Corrigido nome da variável

    private String DS_MATERIA;
    private String ST_MATERIA;

    @ManyToOne
    @JoinColumn(name = "serie_id")
    private SerieEntity serie;

    @OneToOne
    @JoinColumn(name = "rede_id")
    private RedeEntity rede;


    public MateriaEntity(String DS_MATERIA, String ST_MATERIA) {
        this.DS_MATERIA = DS_MATERIA;
        this.ST_MATERIA = ST_MATERIA;
    }

    public MateriaEntity(UUID id ,String DS_MATERIA, String ST_MATERIA) {
        this.DS_MATERIA = DS_MATERIA;
        this.ST_MATERIA = ST_MATERIA;
        this.id = id;
    }


    public MateriaEntity() {}

    public UUID getId() {
        return id;
    }

    public String getDS_MATERIA() {
        return DS_MATERIA;
    }

    public void setDS_MATERIA(String DS_MATERIA) {
        this.DS_MATERIA = DS_MATERIA;
    }

    public String getST_MATERIA() {
        return ST_MATERIA;
    }

    public void setST_MATERIA(String ST_MATERIA) {
        this.ST_MATERIA = ST_MATERIA;
    }

}
