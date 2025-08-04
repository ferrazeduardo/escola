package com.ferrazeduardo.escola.Serie.infra.repository.Entities;

import com.ferrazeduardo.escola.Serie.domain.Rede;

import java.util.UUID;

public class RedeEntity {
    public RedeEntity(UUID id, String rzSocial) {
        this.id = id;
        this.rzSocial = rzSocial;
    }

    public RedeEntity(){}

    private UUID id;
    private String rzSocial;

    public String getRzSocial() {
        return rzSocial;
    }

    public UUID getId() {
        return id;
    }

}
