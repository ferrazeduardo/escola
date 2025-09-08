package com.ferrazeduardo.escola.Serie.infra.gateway.jpa;

import com.ferrazeduardo.escola.Serie.application.gateways.IAulaRepository;
import com.ferrazeduardo.escola.Serie.domain.entities.Aula;
import com.ferrazeduardo.escola.Serie.infra.gateway.mappers.AulaEntityMapper;
import com.ferrazeduardo.escola.Serie.infra.repository.AulaRepository;
import com.ferrazeduardo.escola.Serie.infra.repository.Entities.AulaEntity;

public class RepositoryAulaJpa implements IAulaRepository {

    private final AulaRepository _aulaRepository;
    private final AulaEntityMapper _aulaEntityMapper;

    public RepositoryAulaJpa(AulaRepository aulaRepository, AulaEntityMapper aulaEntityMapper){
        _aulaRepository = aulaRepository;
        _aulaEntityMapper = aulaEntityMapper;
    }

    @Override
    public void Inserir(Aula aula) {
        AulaEntity aulaEntity = _aulaEntityMapper.toEntity(aula);
        this._aulaRepository.save(aulaEntity);
    }
}
