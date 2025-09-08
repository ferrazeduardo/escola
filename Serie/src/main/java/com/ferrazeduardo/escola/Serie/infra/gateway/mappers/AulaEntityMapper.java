package com.ferrazeduardo.escola.Serie.infra.gateway.mappers;

import com.ferrazeduardo.escola.Serie.domain.entities.Aula;
import com.ferrazeduardo.escola.Serie.domain.entities.Horario;
import com.ferrazeduardo.escola.Serie.domain.entities.Materia;
import com.ferrazeduardo.escola.Serie.domain.entities.Sala;
import com.ferrazeduardo.escola.Serie.infra.repository.Entities.AulaEntity;
import com.ferrazeduardo.escola.Serie.infra.repository.Entities.HorarioEntity;
import com.ferrazeduardo.escola.Serie.infra.repository.Entities.MateriaEntity;
import com.ferrazeduardo.escola.Serie.infra.repository.Entities.SalaEntity;

public class AulaEntityMapper {
    public AulaEntity toEntity(Aula aula){
        return new AulaEntity(aula.getId() ,aula.getDS_AULA(),new HorarioEntity(aula.getHorario().getId(),aula.getHorario().getLT_TURNO(),aula.getHorario().getHoraInicio(), aula.getHorario().getHoraFim(), aula.getHorario().getST_HORARIO()),new SalaEntity(aula.getSala().getId(),aula.getSala().getNr_sala()) ,new MateriaEntity(aula.getMateria().getId(),aula.getMateria().getDS_MATERIA(),aula.getMateria().getST_MATERIA()) ,aula.getDiaSemana());
    }

    public Aula toDomain(AulaEntity aulaEntity){
        return new Aula(aulaEntity.getId(), aulaEntity.getDS_AULA(), new Horario(aulaEntity.getHorario().getId(), aulaEntity.getHorario().getHoraFim(),aulaEntity.getHorario().getHoraInicio(), aulaEntity.getHorario().getST_HORARIO(),aulaEntity.getHorario().getLT_TURNO() ),new Sala(aulaEntity.getSala().getId(),aulaEntity.getSala().getNR_SALA()),new Materia(aulaEntity.getMateria().getId(),aulaEntity.getMateria().getST_MATERIA(),aulaEntity.getMateria().getDS_MATERIA()),aulaEntity.getDiaSemana());
    }
}
