package com.ferrazeduardo.escola.Serie.infra.repository.Entities;

import jakarta.persistence.JoinColumn;
import jakarta.persistence.OneToMany;
import jakarta.persistence.OneToOne;

import java.util.List;
import java.util.UUID;

public class ProfessorEntity {
    private UUID id;
    @OneToMany
    @JoinColumn(name = "id_materia")
    private List<MateriaEntity> materias;
    private String nome;

    public ProfessorEntity(UUID id, List<MateriaEntity> materias, String nome) {
        this.id = id;
        this.materias = materias;
        this.nome = nome;
    }

    public UUID getId() {
        return id;
    }

    public List<MateriaEntity> getMaterias() {
        return materias;
    }

    public String getNome() {
        return nome;
    }

}
