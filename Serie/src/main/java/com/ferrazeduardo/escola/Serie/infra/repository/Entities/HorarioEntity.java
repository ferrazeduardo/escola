package com.ferrazeduardo.escola.Serie.infra.repository.Entities;

import jakarta.persistence.Entity;
import jakarta.persistence.Table;

import java.time.LocalTime;
import java.util.UUID;

@Entity
@Table(name = "horarios")
public class HorarioEntity {
    public UUID Id;

    public LocalTime HoraInicio;
    public LocalTime HoraFim;

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

    public String ST_HORARIO;
    public String LT_TURNO;

    public HorarioEntity(UUID id,String lt_turno,LocalTime HoraInicio, LocalTime HoraFim ,String st_horario){
        this.setId(id);
        this.setLT_TURNO(lt_turno);
        this.setHoraInicio(HoraInicio);
        this.setHoraFim(HoraFim);
        this.setST_HORARIO(st_horario);
    }
}
