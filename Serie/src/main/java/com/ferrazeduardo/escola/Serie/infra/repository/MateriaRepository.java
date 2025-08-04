package com.ferrazeduardo.escola.Serie.infra.repository;

import com.ferrazeduardo.escola.Serie.infra.repository.Entities.MateriaEntity;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.UUID;

public interface MateriaRepository extends JpaRepository<MateriaEntity, UUID> {
}
