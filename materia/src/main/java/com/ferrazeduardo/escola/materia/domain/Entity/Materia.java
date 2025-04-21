package com.ferrazeduardo.escola.materia.domain.Entity;

import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.Table;
import lombok.EqualsAndHashCode;
import lombok.Getter;
import lombok.NoArgsConstructor;

import java.util.UUID;

@Table(name = "Materia")
@Entity(name = "Materia")
@NoArgsConstructor
//@AllArgsConstructor
@EqualsAndHashCode(of = "id")
public class Materia {


    public Materia(String ST_MATERIA, int ID_REDE, String DS_MATERIA) {
        this.ST_MATERIA = ST_MATERIA;
        this.ID_REDE = ID_REDE;
        this.DS_MATERIA = DS_MATERIA;
        this.id = UUID.randomUUID();
    }
    @Id
    private UUID id;

    public UUID getId() {
        return id;
    }

    public String getST_MATERIA() {
        return ST_MATERIA;
    }

    public int getID_REDE() {
        return ID_REDE;
    }

    public String getDS_MATERIA() {
        return DS_MATERIA;
    }

    private String ST_MATERIA;

    private int ID_REDE;
    private String DS_MATERIA;
}
