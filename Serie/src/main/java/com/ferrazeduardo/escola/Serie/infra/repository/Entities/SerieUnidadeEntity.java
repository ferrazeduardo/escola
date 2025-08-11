package com.ferrazeduardo.escola.Serie.infra.repository.Entities;

import jakarta.persistence.*;

import java.util.UUID;


@Entity
@Table(name = "serie_unidade")
public class SerieUnidadeEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.UUID)
    UUID id;

    @OneToOne
    @JoinColumn(name="sala_id")
    SalaEntity sala;

    // FK para Serie
    @ManyToOne
    @JoinColumn(name = "serie_id")
    SerieEntity serie;

    // FK para Unidade
    @ManyToOne
    @JoinColumn(name = "unidade_id")
    UnidadeEntity unidade;
}
