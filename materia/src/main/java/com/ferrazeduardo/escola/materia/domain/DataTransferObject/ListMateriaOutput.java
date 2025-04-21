package com.ferrazeduardo.escola.materia.domain.DataTransferObject;

import com.ferrazeduardo.escola.materia.domain.Entity.Materia;

import java.util.UUID;

public record ListMateriaOutput(UUID id, String descricao,String status) {

    public ListMateriaOutput(Materia materia){
        this(materia.getId(), materia.getDS_MATERIA(),materia.getST_MATERIA());
    }
}
