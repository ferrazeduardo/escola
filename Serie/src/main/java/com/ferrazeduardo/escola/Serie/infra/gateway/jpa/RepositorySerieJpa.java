package com.ferrazeduardo.escola.Serie.infra.gateway.jpa;

import com.ferrazeduardo.escola.Serie.application.gateways.ISerieRepository;
import com.ferrazeduardo.escola.Serie.domain.entities.Serie;
import com.ferrazeduardo.escola.Serie.infra.gateway.mappers.SerieEntityMapper;
import com.ferrazeduardo.escola.Serie.infra.repository.Entities.SerieEntity;
import com.ferrazeduardo.escola.Serie.infra.repository.SerieRepository;

public class RepositorySerieJpa implements ISerieRepository {

    private final SerieRepository repository;
    private final SerieEntityMapper mapper;

    public RepositorySerieJpa(SerieRepository repository, SerieEntityMapper mapper) {
        this.repository = repository;
        this.mapper = mapper;
    }

    @Override
    public void Inserir(Serie serie) {
        SerieEntity serieEntity = mapper.toEntity(serie);
        this.repository.save(serieEntity);
    }
}
