package com.ferrazeduardo.escola.materia.domain.Entity;

import jakarta.persistence.Entity;
import jakarta.persistence.Table;
import lombok.AllArgsConstructor;
import lombok.EqualsAndHashCode;
import lombok.Getter;
import lombok.NoArgsConstructor;

import java.util.UUID;

@Table(name = "Materia")
@Entity(name = "Materia")
@Getter
@NoArgsConstructor
//@AllArgsConstructor
@EqualsAndHashCode(of = "Id")
public class Materia {


    public Materia(String ST_MATERIA, int ID_REDE, String DS_MATERIA) {
        this.ST_MATERIA = ST_MATERIA;
        this.ID_REDE = ID_REDE;
        this.DS_MATERIA = DS_MATERIA;
        this.Id = UUID.randomUUID();
    }

    @Id
    private UUID Id;
    private String ST_MATERIA;



    private int ID_REDE;
    private String DS_MATERIA;
}
