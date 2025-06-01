package com.ferrazeduardo.escola.Serie.infra.repository.Entities;

import jakarta.persistence.*;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.UUID;


@Entity
@Table(name = "valor")
public class ValorSerieEntity implements Serializable {
    @Id
    @GeneratedValue(strategy = GenerationType.UUID)
    private UUID id;

    @Column(name = "vl_serie", nullable = false)
    private BigDecimal vlSerie;

    @Column(name = "ds_turno", nullable = false)
    private String dsTurno;

    @ManyToOne
    @JoinColumn(name = "serie_id")
    private SerieEntity serie;


    public ValorSerieEntity(BigDecimal vlSerie, String dsTurno) {
        this.vlSerie = vlSerie;
        this.dsTurno = dsTurno;
    }

    public ValorSerieEntity() {}

    public UUID getId() {
        return id;
    }

    public BigDecimal getVlSerie() {
        return vlSerie;
    }

    public void setVlSerie(BigDecimal vlSerie) {
        this.vlSerie = vlSerie;
    }

    public String getDsTurno() {
        return dsTurno;
    }

    public void setDsTurno(String dsTurno) {
        this.dsTurno = dsTurno;
    }

}
