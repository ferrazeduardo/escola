package com.ferrazeduardo.escola.Serie.infra.gateway.mappers;

import com.ferrazeduardo.escola.Serie.domain.Materia;
import com.ferrazeduardo.escola.Serie.infra.repository.Entities.MateriaEntity;

import java.util.UUID;

public class MateriaEntityMapper {

    public MateriaEntity toEntity(Materia materia){
        return new MateriaEntity(materia.getId(),materia.getDS_MATERIA(), materia.getST_MATERIA());
    }

    public Materia toDomain(MateriaEntity materiaEntity){
        return new Materia(materiaEntity.getId(), materiaEntity.getST_MATERIA(), materiaEntity.getDS_MATERIA());
    }
}
