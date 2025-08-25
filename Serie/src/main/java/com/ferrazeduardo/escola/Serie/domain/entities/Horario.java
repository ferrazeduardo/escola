package com.ferrazeduardo.escola.Serie.domain.entities;

import java.time.LocalTime;
import java.util.UUID;

public class Horario {
    public UUID Id;

    public LocalTime HoraInicio;
    public LocalTime HoraFim;

    public String ST_HORARIO;
    public String LT_TURNO;
    public Horario(LocalTime horaFim, LocalTime horaInicio) {
        HoraFim = horaFim;
        HoraInicio = horaInicio;
    }

    public Horario(){}
}
