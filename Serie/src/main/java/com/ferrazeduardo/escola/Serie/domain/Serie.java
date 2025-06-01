package com.ferrazeduardo.escola.Serie.domain;
import java.math.BigDecimal;
import java.util.Date;
import java.util.List;
import java.util.UUID;


public class Serie {


    public Serie(int AA_MATRICULA, int QT_AVALIACAO, UUID ID_REDE, BigDecimal VL_MEDIA, Date DT_INICIO, Date DT_FIM) {
        this.AA_MATRICULA = AA_MATRICULA;
        this.QT_AVALIACAO = QT_AVALIACAO;
        this.ID_REDE = ID_REDE;
        this.VL_MEDIA = VL_MEDIA;
        this.DT_INICIO = DT_INICIO;
        this.DT_FIM = DT_FIM;
    }


    public Serie(UUID id,int AA_MATRICULA, int QT_AVALIACAO, UUID ID_REDE, BigDecimal VL_MEDIA, Date DT_INICIO, Date DT_FIM) {
        this.AA_MATRICULA = AA_MATRICULA;
        this.QT_AVALIACAO = QT_AVALIACAO;
        this.ID_REDE = ID_REDE;
        this.VL_MEDIA = VL_MEDIA;
        this.DT_INICIO = DT_INICIO;
        this.DT_FIM = DT_FIM;
        this.id = id;
    }

    private UUID id;

    public UUID getId() {
        return id;
    }

    public int getAA_MATRICULA() {
        return AA_MATRICULA;
    }

    public int getQT_AVALIACAO() {
        return QT_AVALIACAO;
    }

    public UUID getID_REDE() {
        return ID_REDE;
    }

    public BigDecimal getVL_MEDIA() {
        return VL_MEDIA;
    }

    public Date getDT_INICIO() {
        return DT_INICIO;
    }

    public Date getDT_FIM() {
        return DT_FIM;
    }

    private int AA_MATRICULA;
    private int QT_AVALIACAO;
    private UUID ID_REDE;
    private BigDecimal VL_MEDIA;
    private Date DT_INICIO;
    private Date DT_FIM;

    private List<ValorSerie> valores;

    private List<Materia> materias;
}
