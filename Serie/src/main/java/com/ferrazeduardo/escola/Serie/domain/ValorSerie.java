package com.ferrazeduardo.escola.Serie.domain;

import jakarta.persistence.*;

import java.math.BigDecimal;
import java.util.UUID;

@Entity
@Table(name = "Valor_Series")
public class ValorSerie {

    public ValorSerie(BigDecimal VL_SERIE, String DS_TURNO) {
        this.VL_SERIE = VL_SERIE;
        this.DS_TURNO = DS_TURNO;
    }

    @Column(nullable = false)
    private BigDecimal VL_SERIE;
    @Column(nullable = false,length = 10)
    private String DS_TURNO;

    public void setSerie(Serie serie) {
        this.serie = serie;
    }

    @ManyToOne
    @JoinColumn(name = "ID_SERIE", nullable = false)
    private Serie serie;
}
