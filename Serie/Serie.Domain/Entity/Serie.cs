using System;

namespace Serie.Domain.Entity;

public class Serie : SeedWorks.Entity
{

    public Serie(int AA_MATRICULA, int QT_AVALIACAO, Rede rede, Decimal VL_MEDIA, DateTime DT_INICIO, DateTime DT_FIM) {
        this.AA_MATRICULA = AA_MATRICULA;
        this.QT_AVALIACAO = QT_AVALIACAO;
        this.rede = rede;
        this.VL_MEDIA = VL_MEDIA;
        this.DT_INICIO = DT_INICIO;
        this.DT_FIM = DT_FIM;
    }


    public Serie(Guid id,int AA_MATRICULA, int QT_AVALIACAO, Rede rede, Decimal VL_MEDIA, DateTime DT_INICIO, DateTime DT_FIM) {
        this.AA_MATRICULA = AA_MATRICULA;
        this.QT_AVALIACAO = QT_AVALIACAO;
        this.rede = rede;
        this.VL_MEDIA = VL_MEDIA;
        this.DT_INICIO = DT_INICIO;
        this.DT_FIM = DT_FIM;
        this.setId(id);
    }


    public int getNr_sala() {
        return nr_sala;
    }

    public void setNr_sala(int nr_sala) {
        this.nr_sala = nr_sala;
    }

    private int nr_sala;

  

    public int getAA_MATRICULA() {
        return AA_MATRICULA;
    }

    public int getQT_AVALIACAO() {
        return QT_AVALIACAO;
    }


    public Decimal getVL_MEDIA() {
        return VL_MEDIA;
    }

    public DateTime getDT_INICIO() {
        return DT_INICIO;
    }

    public DateTime getDT_FIM() {
        return DT_FIM;
    }

    public int AA_MATRICULA { get; private set; }
    public int QT_AVALIACAO { get; private set; }
    public Decimal VL_MEDIA { get; private set; }
    public DateTime DT_INICIO { get; private set; }
    public DateTime DT_FIM { get; private set; }


    public Rede getRede() {
        return rede;
    }

    public void setRede(Rede rede) {
        this.rede = rede;
    }


    public void setMaterias(List<Materia> materias) {
        this.materias = materias;
    }

  

   

    public ICollection<Materia> materias { get; private set; } = [];
    public Rede rede { get; private set; }
    public Sala sala { get; private set; }
    public ICollection<ValorSerie> ValorSeries { get; private set; } = [];
    public ICollection<Aula> aulas { get; private set; } = [];

  
}
