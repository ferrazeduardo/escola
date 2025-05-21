package com.ferrazeduardo.escola.materia.application.gateways;

import com.ferrazeduardo.escola.materia.domain.Entity.Materia;

import java.util.List;
import java.util.UUID;

public interface IMateriaRepository {
    void Inserir(Materia materia);
    List<Materia> Listar(UUID codigoRede);
}
