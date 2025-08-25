package com.ferrazeduardo.escola.Serie.infra.gateway.jpa;

import com.ferrazeduardo.escola.Serie.application.gateways.IMateriaRepository;
import com.ferrazeduardo.escola.Serie.domain.entities.Materia;
import com.ferrazeduardo.escola.Serie.infra.gateway.mappers.MateriaEntityMapper;
import com.ferrazeduardo.escola.Serie.infra.repository.Entities.MateriaEntity;
import com.ferrazeduardo.escola.Serie.infra.repository.MateriaRepository;

public class RepositoryMateriaJpa implements IMateriaRepository {

    private final MateriaRepository _materiaRepository;
    private final MateriaEntityMapper _materiaEntityMapper;

    public RepositoryMateriaJpa(MateriaRepository materiaRepository, MateriaEntityMapper materiaEntityMapper){
        _materiaRepository = materiaRepository;
        _materiaEntityMapper = materiaEntityMapper;
    }

    @Override
    public void Inserir(Materia materia) {
        MateriaEntity materiaEntity = _materiaEntityMapper.toEntity(materia);
        this._materiaRepository.save(materiaEntity);
    }
}
