package com.ferrazeduardo.escola.Serie.infra.repository;

import com.ferrazeduardo.escola.Serie.infra.repository.Entities.AulaEntity;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.UUID;

public interface AulaRepository extends JpaRepository<AulaEntity, UUID> {
}
