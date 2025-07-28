package com.ferrazeduardo.escola.Serie.infra.repository.Entities;

import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;

import java.util.UUID;

public class SalaEntity {

    public SalaEntity(UUID id, String NR_SALA) {
        this.id = id;
        this.NR_SALA = NR_SALA;
    }

    public UUID getId() {
        return id;
    }

    public String getNR_SALA() {
        return NR_SALA;
    }

    @Id
    @GeneratedValue(strategy = GenerationType.UUID)
    public UUID id;

    public String NR_SALA;
}
