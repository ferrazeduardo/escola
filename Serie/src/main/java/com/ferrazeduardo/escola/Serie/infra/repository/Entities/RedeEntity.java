package com.ferrazeduardo.escola.Serie.infra.repository.Entities;

import com.ferrazeduardo.escola.Serie.domain.Rede;
import jakarta.persistence.*;

import java.util.UUID;

@Entity
@Table(name = "rede")
public class RedeEntity {
    public RedeEntity(UUID id, String rzSocial) {
        this.id = id;
        this.rzSocial = rzSocial;
    }

    public RedeEntity(){}

    @Id
    @GeneratedValue(strategy = GenerationType.UUID)
    private UUID id;
    private String rzSocial;

    public String getRzSocial() {
        return rzSocial;
    }

    public UUID getId() {
        return id;
    }

}
