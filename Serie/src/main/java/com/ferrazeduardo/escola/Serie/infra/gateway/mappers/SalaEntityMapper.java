package com.ferrazeduardo.escola.Serie.infra.gateway.mappers;

import com.ferrazeduardo.escola.Serie.domain.entities.Sala;
import com.ferrazeduardo.escola.Serie.infra.repository.Entities.SalaEntity;

public class SalaEntityMapper {

    public SalaEntity toEntitu(Sala sala){
        return new SalaEntity(sala.getId(),sala.getNr_sala());
    }

    public Sala toDomain(SalaEntity salaEntity){
        return new Sala(salaEntity.getId(),salaEntity.getNR_SALA());
    }

}
