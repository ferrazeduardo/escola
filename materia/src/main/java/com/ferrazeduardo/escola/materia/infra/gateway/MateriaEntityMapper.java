package com.ferrazeduardo.escola.materia.infra.gateway;

import com.ferrazeduardo.escola.materia.domain.Entity.Materia;
import com.ferrazeduardo.escola.materia.infra.repository.MateriaEntity;

public class MateriaEntityMapper {
    public MateriaEntity toEntity(Materia materia){
        return new MateriaEntity(materia.getId(),materia.getST_MATERIA(),materia.getRede().getId(),materia.getDS_MATERIA());
    }


    public Materia toDomain(MateriaEntity materiaEntity){
        return new Materia(materiaEntity.getId(),materiaEntity.getDS_MATERIA(),materiaEntity.getST_MATERIA(),materiaEntity.getID_REDE());
    }
}
