package com.ferrazeduardo.escola.Serie.domain;

import jakarta.persistence.*;

import java.math.BigDecimal;
import java.rmi.server.UID;
import java.util.Date;
import java.util.List;
import java.util.UUID;

@Entity
@Table(name = "serie")
public class Serie {


    public Serie(int AA_MATRICULA, int QT_AVALIACAO, UUID ID_REDE, BigDecimal VL_MEDIA, Date DT_INICIO, Date DT_FIM) {
        this.AA_MATRICULA = AA_MATRICULA;
        this.QT_AVALIACAO = QT_AVALIACAO;
        this.ID_REDE = ID_REDE;
        this.VL_MEDIA = VL_MEDIA;
        this.DT_INICIO = DT_INICIO;
        this.DT_FIM = DT_FIM;
        this.Id = UUID.randomUUID();
    }
    @Id
    private UUID Id;

    public UUID getId() {
        return Id;
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

    @Column(nullable = false)
    private int AA_MATRICULA;
    @Column(nullable = false)
    private int QT_AVALIACAO;
    @Column(nullable = false)
    private UUID ID_REDE;
    @Column(nullable = false)
    private BigDecimal VL_MEDIA;
    @Column(nullable = false)
    private Date DT_INICIO;
    @Column(nullable = false)
    private Date DT_FIM;

    @OneToMany(mappedBy = "serie", cascade = CascadeType.ALL, orphanRemoval = true)
    private List<ValorSerie> valores;

    @OneToMany(mappedBy = "materia",cascade = CascadeType.ALL,orphanRemoval = true)
    private List<Materia> materias;
}
