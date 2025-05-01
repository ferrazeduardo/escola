package com.ferrazeduardo.escola.materia.domain.Factory;

import com.ferrazeduardo.escola.materia.domain.Entity.Materia;
import com.ferrazeduardo.escola.materia.domain.Entity.Rede;

import java.util.UUID;

public class FactoryMateria {
    private Materia materia;

    public Materia comDescricao(String descricao){
          this.materia = new Materia(descricao);
          return this.materia;
    }

    public Materia incluiRede(UUID ID_REDE, String razaoSOcial){
        this.materia.setRede(new Rede(ID_REDE, razaoSOcial));
        return this.materia;
    }
}
