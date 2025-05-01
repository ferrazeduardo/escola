package com.ferrazeduardo.escola.materia.domain.Entity;

import java.util.UUID;

public class Rede {

    public Rede(UUID idRede, String razaoSOcial) {
        setId(idRede);
        setRZ_SOCIAL(razaoSOcial);
    }

    public UUID getId() {
        return Id;
    }

    public void setId(UUID id) {
        Id = id;
    }

    public String getRZ_SOCIAL() {
        return RZ_SOCIAL;
    }

    public void setRZ_SOCIAL(String RZ_SOCIAL) {
        this.RZ_SOCIAL = RZ_SOCIAL;
    }

    private UUID Id;
    private String RZ_SOCIAL;
}
