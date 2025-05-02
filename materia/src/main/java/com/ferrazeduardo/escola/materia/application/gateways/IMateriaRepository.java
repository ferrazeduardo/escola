package com.ferrazeduardo.escola.materia.application.gateways;

import com.ferrazeduardo.escola.materia.domain.Entity.Materia;

import java.util.List;

public interface IMateriaRepository {
    void Inserir(Materia materia);
    List<Materia> Listar();
}
