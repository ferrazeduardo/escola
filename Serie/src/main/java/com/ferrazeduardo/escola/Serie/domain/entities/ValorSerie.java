package com.ferrazeduardo.escola.Serie.domain.entities;

import java.math.BigDecimal;
import java.util.UUID;

public class ValorSerie {

    public ValorSerie(BigDecimal VL_SERIE, String DS_TURNO) {
        this.VL_SERIE = VL_SERIE;
        this.DS_TURNO = DS_TURNO;
    }

    private UUID id;

    public ValorSerie(BigDecimal vlSerie, String dsTurno, UUID id) {
        this.id = id;
        this.VL_SERIE = vlSerie;
        this.DS_TURNO = dsTurno;
    }

    public BigDecimal getVL_SERIE() {
        return VL_SERIE;
    }

    public UUID getId() {
        return id;
    }

    public String getDS_TURNO() {
        return DS_TURNO;
    }

    private BigDecimal VL_SERIE;
    private String DS_TURNO;


}
