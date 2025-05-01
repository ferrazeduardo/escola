package com.ferrazeduardo.escola.materia.domain.entity.materia;

import com.ferrazeduardo.escola.materia.domain.Entity.Materia;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

import java.util.UUID;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class MateriaTest
{
    @Test
    public void AtivarMateria(){
        Materia materia = new Materia();
        materia.MateriaAtiva();

        assertEquals("S", materia.getST_MATERIA());
    }

    @Test
    public void DesativarMateria(){
        Materia materia = new Materia();
        materia.MateriaDesativada();

        assertEquals("N",materia.getST_MATERIA());
    }

    @Test
    public void LancarExcecaoQuandoNaoInformarIdREde(){
      Assertions.assertThrows(IllegalArgumentException.class, () -> new Materia(null, "matematica"));
    }

    @Test
    public void LancarExcecaoQuandoDsMateriaForNull(){
        Assertions.assertThrows(IllegalArgumentException.class, () -> new Materia(UUID.randomUUID(), null));
    }

    @Test
    public void LancarExcecaoQuandoDsMateriaForEmpty(){
        Assertions.assertThrows(IllegalArgumentException.class, () -> new Materia(UUID.randomUUID(), ""));
    }

    @Test
    public void LancarExcecaoQuandoDsMateriaTiverMaisDeCincoentaDigitos(){
        Assertions.assertThrows(IllegalArgumentException.class, () -> new Materia(UUID.randomUUID(), "a".repeat(100)));
    }
}
