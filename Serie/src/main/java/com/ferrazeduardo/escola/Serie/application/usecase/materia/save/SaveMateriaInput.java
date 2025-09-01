package com.ferrazeduardo.escola.Serie.application.usecase.materia.save;

import java.util.UUID;

public record SaveMateriaInput(String descricaoMateria, UUID idRede) {
}
