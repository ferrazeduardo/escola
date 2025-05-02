package com.ferrazeduardo.escola.materia.domain.Entity;

import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.Table;
import jakarta.validation.constraints.NotBlank;
import lombok.EqualsAndHashCode;
import lombok.Getter;
import lombok.NoArgsConstructor;

import java.util.UUID;


public class Materia {
    private UUID id;
    private Rede Rede;

    private String ST_MATERIA;

    private UUID ID_REDE;

    private String DS_MATERIA;
    public Materia(UUID ID_REDE, String DS_MATERIA) {
        this.ID_REDE = ID_REDE;
        this.DS_MATERIA = DS_MATERIA;
        this.id = UUID.randomUUID();
        MateriaAtiva();
        Validacoes();
    }

    public Materia(String DS_MATERIA){
        this.DS_MATERIA = DS_MATERIA;
    }


    public Materia(){

    }

    public Materia(UUID id, String dsMateria, String stMateria, UUID idRede) {

    }

    public UUID getId() {
        return id;
    }

    public String getST_MATERIA() {
        return ST_MATERIA;
    }

    public UUID getID_REDE() {
        return ID_REDE;
    }

    public String getDS_MATERIA() {
        return DS_MATERIA;
    }

    public Rede getRede() {
        return Rede;
    }

    public void setRede(Rede rede) {
        Rede = rede;
    }




    public void MateriaAtiva(){
        ST_MATERIA = "S";
    }


    public void MateriaDesativada(){
        ST_MATERIA = "N";
    }



    public void Validacoes(){
        if(ID_REDE == null)
            throw  new IllegalArgumentException("id da rede não pode ser nulo");

        if(DS_MATERIA == null)
            throw  new IllegalArgumentException("descrição da matéria não pode ser nulo");

        if(DS_MATERIA.length() > 50)
            throw  new IllegalArgumentException("descrição da matéria não pode ter mais de 50 caracteres");

        if(DS_MATERIA.length() == 0)
            throw  new IllegalArgumentException("por favor, informar descrição da materia");


    }
}
