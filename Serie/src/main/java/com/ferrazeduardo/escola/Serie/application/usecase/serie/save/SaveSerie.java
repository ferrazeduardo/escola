package com.ferrazeduardo.escola.Serie.application.usecase.serie.save;

import com.ferrazeduardo.escola.Serie.application.gateways.ISerieRepository;
import com.ferrazeduardo.escola.Serie.domain.Serie;

public class SaveSerie {

    private final ISerieRepository _serieRepository;

    public SaveSerie(ISerieRepository serieRepository){
        _serieRepository = serieRepository;
    }


    public SerieOutput Handler(SerieInput serieInput){
        Serie serie = new Serie(serieInput.ano(),serieInput.quantidadeAvalicao(),serieInput.id_rede(),serieInput.valorMedia(),serieInput.dataInicio(),serieInput.DataFim());

        _serieRepository.Inserir(serie);

        SerieOutput serieOutput = new SerieOutput();
        return serieOutput;
    }
}


