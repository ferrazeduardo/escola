package com.ferrazeduardo.escola.Serie.domain;

import java.util.UUID;

public class Sala {
    public UUID getId() {
        return id;
    }

    public void setId(UUID id) {
        this.id = id;
    }

    public int getNr_sala() {
        return nr_sala;
    }

    public void setNr_sala(int nr_sala) {
        this.nr_sala = nr_sala;
    }

    private UUID id;
    private int nr_sala;
}
