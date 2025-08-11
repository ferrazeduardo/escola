package com.ferrazeduardo.escola.Serie.infra.repository.Entities;

import jakarta.persistence.*;

import java.util.List;
import java.util.UUID;

@Entity
@Table(name = "unidade")
public class UnidadeEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.UUID)
    public UUID id;

    public String DS_UNIDADE;

    public UUID getId() {
        return id;
    }

    public String getDS_UNIDADE() {
        return DS_UNIDADE;
    }


    public UnidadeEntity(UUID id, String DS_UNIDADE) {
        this.id = id;
        this.DS_UNIDADE = DS_UNIDADE;
    }

    public UnidadeEntity(){}



    @OneToMany(mappedBy = "unidade", cascade = CascadeType.ALL, fetch = FetchType.LAZY)
    private List<SalaEntity> salas;
}
