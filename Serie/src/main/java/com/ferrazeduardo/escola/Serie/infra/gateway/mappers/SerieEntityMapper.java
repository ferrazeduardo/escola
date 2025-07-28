package com.ferrazeduardo.escola.Serie.infra.gateway.mappers;

import com.ferrazeduardo.escola.Serie.domain.Serie;
import com.ferrazeduardo.escola.Serie.infra.repository.Entities.SerieEntity;

public class SerieEntityMapper {

    public SerieEntity toEntity(Serie serie){
        return new SerieEntity(serie.getId(),serie.getAA_MATRICULA(),serie.getQT_AVALIACAO(),serie.getID_UNIDADE(),serie.getVL_MEDIA(),serie.getDT_INICIO(),serie.getDT_FIM());
    }

    public Serie toDomain(SerieEntity serieEntity){
        return new Serie(serieEntity.getId(),serieEntity.getAA_MATRICULA(),serieEntity.getQT_AVALIACAO(),serieEntity.getID_UNIDADE(),serieEntity.getVL_MEDIA(),serieEntity.getDT_INICIO(),serieEntity.getDT_FIM());
    }

}
