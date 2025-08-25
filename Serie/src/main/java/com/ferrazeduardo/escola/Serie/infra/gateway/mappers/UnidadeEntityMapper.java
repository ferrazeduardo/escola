package com.ferrazeduardo.escola.Serie.infra.gateway.mappers;

import com.ferrazeduardo.escola.Serie.domain.entities.Unidade;
import com.ferrazeduardo.escola.Serie.infra.repository.Entities.UnidadeEntity;

public class UnidadeEntityMapper {
    public UnidadeEntity toEntity(Unidade unidade){
    return  new UnidadeEntity(unidade.getID_UNIDADE(),unidade.getDS_UNIDADE());
    }

    public Unidade toDomain(UnidadeEntity unidadeEntity){
        return new Unidade(unidadeEntity.getId(),unidadeEntity.getDS_UNIDADE());
    }
}
