package com.ferrazeduardo.escola.Serie.infra.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import java.util.UUID;

public interface SerieRepository extends JpaRepository<SerieEntity, UUID> {
}
