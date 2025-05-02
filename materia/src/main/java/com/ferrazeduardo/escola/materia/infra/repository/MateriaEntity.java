package com.ferrazeduardo.escola.materia.infra.repository;

import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.Table;

import java.util.UUID;

@Entity
@Table(name = "materia")
public class MateriaEntity {

    @Id
    private UUID id;
    private String ST_MATERIA;

    private UUID ID_REDE;

    private String DS_MATERIA;

    public UUID getId() {
        return id;
    }

    public void setId(UUID id) {
        this.id = id;
    }

    public String getST_MATERIA() {
        return ST_MATERIA;
    }

    public void setST_MATERIA(String ST_MATERIA) {
        this.ST_MATERIA = ST_MATERIA;
    }

    public UUID getID_REDE() {
        return ID_REDE;
    }

    public void setID_REDE(UUID ID_REDE) {
        this.ID_REDE = ID_REDE;
    }

    public String getDS_MATERIA() {
        return DS_MATERIA;
    }

    public void setDS_MATERIA(String DS_MATERIA) {
        this.DS_MATERIA = DS_MATERIA;
    }



    public MateriaEntity(UUID id, String ST_MATERIA, UUID ID_REDE, String DS_MATERIA) {
        this.id = id;
        this.ST_MATERIA = ST_MATERIA;
        this.ID_REDE = ID_REDE;
        this.DS_MATERIA = DS_MATERIA;
    }

    public MateriaEntity(){

    }


}
