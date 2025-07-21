package com.ferrazeduardo.escola.Serie.domain;
import java.math.BigDecimal;
import java.util.Date;
import java.util.List;
import java.util.UUID;


public class Serie {


    public Serie(int AA_MATRICULA, int QT_AVALIACAO, UUID ID_UNIDADE, BigDecimal VL_MEDIA, Date DT_INICIO, Date DT_FIM) {
        this.AA_MATRICULA = AA_MATRICULA;
        this.QT_AVALIACAO = QT_AVALIACAO;
        this.ID_UNIDADE = ID_UNIDADE;
        this.VL_MEDIA = VL_MEDIA;
        this.DT_INICIO = DT_INICIO;
        this.DT_FIM = DT_FIM;
    }


    public Serie(UUID id,int AA_MATRICULA, int QT_AVALIACAO, UUID ID_UNIDADE, BigDecimal VL_MEDIA, Date DT_INICIO, Date DT_FIM) {
        this.AA_MATRICULA = AA_MATRICULA;
        this.QT_AVALIACAO = QT_AVALIACAO;
        this.ID_UNIDADE = ID_UNIDADE;
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

    public UUID getID_UNIDADE() {
        return ID_UNIDADE;
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
    private UUID ID_UNIDADE;
    private BigDecimal VL_MEDIA;
    private Date DT_INICIO;
    private Date DT_FIM;

    private List<ValorSerie> valores;

    public Unidade getUnidade() {
        return unidade;
    }

    public void setUnidade(Unidade unidade) {
        this.unidade = unidade;
    }

    public List<Materia> getMaterias() {
        return materias;
    }

    public void setMaterias(List<Materia> materias) {
        this.materias = materias;
    }

    public List<ValorSerie> getValores() {
        return valores;
    }

    public void setValores(List<ValorSerie> valores) {
        this.valores = valores;
    }

    private List<Materia> materias;
    private Unidade unidade;
}
