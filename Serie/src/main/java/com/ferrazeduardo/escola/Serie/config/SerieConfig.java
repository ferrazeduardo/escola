package com.ferrazeduardo.escola.Serie.config;

import com.ferrazeduardo.escola.Serie.application.gateways.ISerieRepository;
import com.ferrazeduardo.escola.Serie.application.usecase.serie.save.SaveSerie;
import com.ferrazeduardo.escola.Serie.infra.gateway.jpa.RepositorySerieJpa;
import com.ferrazeduardo.escola.Serie.infra.gateway.mappers.SerieEntityMapper;
import com.ferrazeduardo.escola.Serie.infra.repository.SerieRepository;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class SerieConfig {

    @Bean
    SaveSerie criarSerie(ISerieRepository serieRepository){return new SaveSerie(serieRepository);}


    @Bean
    RepositorySerieJpa criarRepositorySerieJpa(SerieRepository serieRepository, SerieEntityMapper mapper){
        return new RepositorySerieJpa(serieRepository,mapper);
    }

    @Bean
    SerieEntityMapper criarSerieEntityMapper(){return new SerieEntityMapper();}
}
