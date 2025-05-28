package com.ferrazeduardo.escola.Serie.infra.repository;

import jakarta.persistence.Entity;
import jakarta.persistence.Table;

import java.math.BigDecimal;


@Entity
@Table(name = "valor")
public class ValorSerieEntity {
    public ValorSerieEntity(BigDecimal VL_SERIE, String DS_TURNO) {
        this.VL_SERIE = VL_SERIE;
        this.DS_TURNO = DS_TURNO;
    }

    private BigDecimal VL_SERIE;
    private String DS_TURNO;

}
