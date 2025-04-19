package com.ferrazeduardo.escola.materia.domain.DataTransferObject;

import jakarta.validation.constraints.NotNull;

import java.util.UUID;

public record MateriaInput(
        @NotNull
        String descricao,
        @NotNull
        UUID id_rede){
}
