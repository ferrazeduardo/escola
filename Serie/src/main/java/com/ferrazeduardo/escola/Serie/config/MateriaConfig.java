package com.ferrazeduardo.escola.Serie.config;

import com.ferrazeduardo.escola.Serie.application.gateways.IMateriaRepository;
import com.ferrazeduardo.escola.Serie.application.usecase.materia.save.SaveMateria;
import com.ferrazeduardo.escola.Serie.infra.gateway.jpa.RepositoryMateriaJpa;
import com.ferrazeduardo.escola.Serie.infra.gateway.mappers.MateriaEntityMapper;
import com.ferrazeduardo.escola.Serie.infra.repository.MateriaRepository;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class MateriaConfig {

    @Bean
    SaveMateria saveMatricula(IMateriaRepository materiaRepository){return new SaveMateria(materiaRepository);}

    @Bean
    RepositoryMateriaJpa criarRepositoryMateriaJpa(MateriaRepository materiaRepository, MateriaEntityMapper mapper){
        return new RepositoryMateriaJpa(materiaRepository,mapper);
    }

    @Bean
    MateriaEntityMapper criarMateriaEntityMapper(){return new MateriaEntityMapper();}
}
