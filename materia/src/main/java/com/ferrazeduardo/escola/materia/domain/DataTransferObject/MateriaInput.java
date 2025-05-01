package com.ferrazeduardo.escola.materia.domain.DataTransferObject;

import jakarta.validation.constraints.NotNull;

import java.util.UUID;

public record MateriaInput(
        String descricao,
        UUID id_rede){
}
