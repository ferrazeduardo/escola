package com.ferrazeduardo.escola.Serie.domain;

import java.util.UUID;

public class Unidade {
    public UUID getID_UNIDADE() {
        return ID_UNIDADE;
    }

    public Unidade(){

    }

    public Unidade(UUID ID_UNIDADE , String DS_UNIDADE){
        setID_UNIDADE(ID_UNIDADE);
        setDS_UNIDADE(DS_UNIDADE);
    }

    public void setID_UNIDADE(UUID ID_UNIDADE) {
        this.ID_UNIDADE = ID_UNIDADE;
    }

    public String getDS_UNIDADE() {
        return DS_UNIDADE;
    }

    public void setDS_UNIDADE(String DS_UNIDADE) {
        this.DS_UNIDADE = DS_UNIDADE;
    }

    private UUID ID_UNIDADE;
    private  String DS_UNIDADE;
}
