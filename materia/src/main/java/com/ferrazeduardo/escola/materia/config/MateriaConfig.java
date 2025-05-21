package com.ferrazeduardo.escola.materia.config;

import com.ferrazeduardo.escola.materia.application.usecases.materia.listar.ListarMateria;
import com.ferrazeduardo.escola.materia.application.usecases.materia.save.SaveMateria;
import com.ferrazeduardo.escola.materia.infra.gateway.MateriaEntityMapper;
import com.ferrazeduardo.escola.materia.infra.gateway.RepositoryMateriaJpa;
import com.ferrazeduardo.escola.materia.infra.repository.MateriaRepository;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import com.ferrazeduardo.escola.materia.application.gateways.IMateriaRepository;

@Configuration
public class MateriaConfig {

    @Bean
    SaveMateria criarMateria(IMateriaRepository materiaRepository){
        return new SaveMateria(materiaRepository);
    }

    @Bean
    ListarMateria listarMateria(IMateriaRepository materiaRepository){return new ListarMateria(materiaRepository);}


    @Bean
    RepositoryMateriaJpa criarRepositoryJpa(MateriaRepository repositorio, MateriaEntityMapper mapper){
        return new RepositoryMateriaJpa( repositorio, mapper);
    }
    @Bean
    MateriaEntityMapper retornarMapper(){
        return new MateriaEntityMapper();
    }
}
