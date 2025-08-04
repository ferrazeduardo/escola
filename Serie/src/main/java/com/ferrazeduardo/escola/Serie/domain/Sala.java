package com.ferrazeduardo.escola.Serie.domain;

import java.util.UUID;

public class Sala {
    public Sala(UUID id, String nrSala) {
        this.id = id;
        this.nr_sala = nrSala;
    }

    public UUID getId() {
        return id;
    }

    public void setId(UUID id) {
        this.id = id;
    }

    public String getNr_sala() {
        return nr_sala;
    }

    public void setNr_sala(String nr_sala) {
        this.nr_sala = nr_sala;
    }

    private UUID id;
    private String nr_sala;
}
