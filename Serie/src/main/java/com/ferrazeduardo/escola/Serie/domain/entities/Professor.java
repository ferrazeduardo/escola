package com.ferrazeduardo.escola.Serie.domain.entities;

import java.util.List;
import java.util.UUID;

public class Professor {
    public Professor(UUID id, String nome, List<Materia> materia) {
        Id = id;
        this.nome = nome;
        this.materia = materia;
    }

    private UUID Id;

    public UUID getId() {
        return Id;
    }

    public String getNome() {
        return nome;
    }

    public List<Materia> getMateria() {
        return materia;
    }

    private String nome;
    private List<Materia> materia;

}
