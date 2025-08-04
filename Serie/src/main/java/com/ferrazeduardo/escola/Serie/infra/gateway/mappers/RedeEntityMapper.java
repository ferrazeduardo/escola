package com.ferrazeduardo.escola.Serie.infra.gateway.mappers;

import com.ferrazeduardo.escola.Serie.domain.Rede;
import com.ferrazeduardo.escola.Serie.infra.repository.Entities.RedeEntity;

public class RedeEntityMapper {
    public RedeEntity toEntity(Rede rede){
        return new RedeEntity(rede.getId(),rede.getRZ_SOCIAL());
    }

    public Rede toDomain(RedeEntity redeEntity){
         return new Rede(redeEntity.getId(),redeEntity.getRzSocial());
    }
}
