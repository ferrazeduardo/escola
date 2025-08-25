package com.ferrazeduardo.escola.Serie.infra.gateway.mappers;

import com.ferrazeduardo.escola.Serie.domain.entities.ValorSerie;
import com.ferrazeduardo.escola.Serie.infra.repository.Entities.ValorSerieEntity;

public class ValorSerieEntityMapper {
    public ValorSerieEntity toEntity(ValorSerie valorSerie){
        return new ValorSerieEntity(valorSerie.getVL_SERIE(), valorSerie.getDS_TURNO(),valorSerie.getId());
    }

    public ValorSerie toDomain(ValorSerieEntity valorSerieEntity){
        return new ValorSerie(valorSerieEntity.getVlSerie(),valorSerieEntity.getDsTurno(),valorSerieEntity.getId());
    }
}
