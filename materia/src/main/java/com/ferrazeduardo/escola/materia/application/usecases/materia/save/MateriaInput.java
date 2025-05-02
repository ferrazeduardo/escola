package com.ferrazeduardo.escola.materia.application.usecases.materia.save;

import java.util.UUID;

public record MateriaInput(
        String descricao,
        UUID id_rede){
}
