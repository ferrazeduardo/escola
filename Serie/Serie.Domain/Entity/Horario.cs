using System;

namespace Serie.Domain.Entity;

public class Horario : SeedWorks.Entity
{

    public TimeSpan getHoraInicio()
    {
        return HoraInicio;
    }

    public void setHoraInicio(TimeSpan horaInicio)
    {
        HoraInicio = horaInicio;
    }

    public TimeSpan getHoraFim()
    {
        return HoraFim;
    }

    public void setHoraFim(TimeSpan horaFim)
    {
        HoraFim = horaFim;
    }

    public String getST_HORARIO()
    {
        return ST_HORARIO;
    }

    public void setST_HORARIO(String ST_HORARIO)
    {
        this.ST_HORARIO = ST_HORARIO;
    }

    public String getLT_TURNO()
    {
        return LT_TURNO;
    }

    public void setLT_TURNO(String LT_TURNO)
    {
        this.LT_TURNO = LT_TURNO;
    }

    public TimeSpan HoraInicio { get; private set; }
    public TimeSpan HoraFim { get; private set; }

    public String ST_HORARIO { get; private set; }
    public String LT_TURNO { get; private set; }

    public Horario() { }

    public Horario(TimeSpan horaFim, TimeSpan horaInicio)
    {
        HoraFim = horaFim;
        HoraInicio = horaInicio;
        this.IdentificarTurno();
        this.Ativar();
    }


    public Horario(Guid id, TimeSpan horaFim, TimeSpan horaInicio, String st_horario, String lt_turno)
    {
        this.setId(id);
        HoraFim = horaFim;
        HoraInicio = horaInicio;
        this.LT_TURNO = lt_turno;
        this.ST_HORARIO = st_horario;
    }

    public void Ativar()
    {
        this.ST_HORARIO = "S";
    }

    private void IdentificarTurno()
    {
        if (HoraInicio == null) return;

        if (HoraInicio < new TimeSpan(12, 0, 0))
        {
            LT_TURNO = "Manhã";
        }
        else if (HoraInicio < new TimeSpan(18, 0, 0))
        {
            LT_TURNO = "Tarde";
        }
        else
        {
            LT_TURNO = "Noite";
        }
    }

}
