package com.ferrazeduardo.escola.Serie.infra.repository.Entities;

import jakarta.persistence.*;

import java.util.UUID;

@Entity
@Table(name = "sala")
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

    @ManyToOne
    @JoinColumn(name = "id_unidade")
    private UnidadeEntity unidade;

}
