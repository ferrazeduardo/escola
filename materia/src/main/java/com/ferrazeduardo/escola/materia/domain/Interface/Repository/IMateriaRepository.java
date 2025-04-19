package com.ferrazeduardo.escola.materia.domain.Interface.Repository;

import com.ferrazeduardo.escola.materia.domain.Entity.Materia;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.UUID;

public interface IMateriaRepository extends JpaRepository<Materia, UUID> {
}
