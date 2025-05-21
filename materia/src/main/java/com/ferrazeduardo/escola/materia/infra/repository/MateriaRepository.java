package com.ferrazeduardo.escola.materia.infra.repository;

import com.ferrazeduardo.escola.materia.domain.Entity.Materia;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.Arrays;
import java.util.List;
import java.util.UUID;

public interface MateriaRepository extends JpaRepository<MateriaEntity, UUID> {
    List<MateriaEntity> findAllById(UUID idRede);
}
