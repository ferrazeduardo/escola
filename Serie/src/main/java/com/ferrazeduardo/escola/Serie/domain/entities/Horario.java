package com.ferrazeduardo.escola.Serie.domain.entities;

import java.time.LocalTime;
import java.util.UUID;

public class Horario {
    private UUID Id;

    public UUID getId() {
        return Id;
    }

    public void setId(UUID id) {
        Id = id;
    }

    public LocalTime getHoraInicio() {
        return HoraInicio;
    }

    public void setHoraInicio(LocalTime horaInicio) {
        HoraInicio = horaInicio;
    }

    public LocalTime getHoraFim() {
        return HoraFim;
    }

    public void setHoraFim(LocalTime horaFim) {
        HoraFim = horaFim;
    }

    public String getST_HORARIO() {
        return ST_HORARIO;
    }

    public void setST_HORARIO(String ST_HORARIO) {
        this.ST_HORARIO = ST_HORARIO;
    }

    public String getLT_TURNO() {
        return LT_TURNO;
    }

    public void setLT_TURNO(String LT_TURNO) {
        this.LT_TURNO = LT_TURNO;
    }

    private LocalTime HoraInicio;
    private LocalTime HoraFim;

    private String ST_HORARIO;
    private String LT_TURNO;

    public Horario(){}

    public Horario(LocalTime horaFim, LocalTime horaInicio) {
        HoraFim = horaFim;
        HoraInicio = horaInicio;
        this.identificarTurno();
        this.Ativar();
    }


    public Horario(UUID id ,LocalTime horaFim, LocalTime horaInicio,String st_horario,String lt_turno) {
        this.Id = id;
        HoraFim = horaFim;
        HoraInicio = horaInicio;
        this.LT_TURNO = lt_turno;
        this.ST_HORARIO = st_horario;
    }

    public void Ativar(){
        this.ST_HORARIO = "S";
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
