package com.ferrazeduardo.escola.Serie.domain;

import java.util.List;
import java.util.UUID;

public class Rede {

    private List<Unidade> unidades;

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

    private List<Unidade> ListUnidades(){
        return unidades;
    }

    public void setUnidades(List<Unidade> unidades){
        this.unidades = unidades;
    }
}
