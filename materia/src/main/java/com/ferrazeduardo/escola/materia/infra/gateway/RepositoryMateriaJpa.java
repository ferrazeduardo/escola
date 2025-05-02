package com.ferrazeduardo.escola.materia.infra.gateway;

import com.ferrazeduardo.escola.materia.application.gateways.IMateriaRepository;
import com.ferrazeduardo.escola.materia.domain.Entity.Materia;
import com.ferrazeduardo.escola.materia.infra.repository.MateriaEntity;
import com.ferrazeduardo.escola.materia.infra.repository.MateriaRepository;

import java.util.List;

public class RepositoryMateriaJpa implements IMateriaRepository {

    private final MateriaRepository repository;
    private final MateriaEntityMapper mapper;

    public RepositoryMateriaJpa(MateriaRepository repository,MateriaEntityMapper mapper) {
        this.repository = repository;
        this.mapper = mapper;
    }

    @Override
    public void Inserir(Materia materia) {
        MateriaEntity materiaEntity = mapper.toEntity(materia);
        this.repository.save(materiaEntity);
    }

    @Override
    public List<Materia> Listar(){
        return null;
    }
}
