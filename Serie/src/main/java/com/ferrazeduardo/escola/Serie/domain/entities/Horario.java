package com.ferrazeduardo.escola.Serie.domain.entities;

import java.time.LocalTime;
import java.util.UUID;

public class Horario {
    public UUID Id;

    public LocalTime HoraInicio;
    public LocalTime HoraFim;

    public String ST_HORARIO;
    public String LT_TURNO;

    public Horario(){}

    public Horario(LocalTime horaFim, LocalTime horaInicio) {
        HoraFim = horaFim;
        HoraInicio = horaInicio;
        this.identificarTurno();
    }

    private void identificarTurno() {
        if (HoraInicio == null) return;

        if (HoraInicio.isBefore(LocalTime.of(12, 0))) {
            LT_TURNO = "Manhã";
        } else if (HoraInicio.isBefore(LocalTime.of(18, 0))) {
            LT_TURNO = "Tarde";
        }

        LT_TURNO = "Noite";
    }

}
