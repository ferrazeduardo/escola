package com.ferrazeduardo.escola.Serie.domain;

import jakarta.persistence.*;

import java.math.BigDecimal;
import java.util.UUID;

public class ValorSerie {

    public ValorSerie(BigDecimal VL_SERIE, String DS_TURNO) {
        this.VL_SERIE = VL_SERIE;
        this.DS_TURNO = DS_TURNO;
    }

    private BigDecimal VL_SERIE;
    private String DS_TURNO;


}
