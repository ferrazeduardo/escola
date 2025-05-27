package com.ferrazeduardo.escola.Serie.application.usecase.save;

import com.ferrazeduardo.escola.Serie.application.gateways.ISerieRepository;

public class SaveSerie {

    private final ISerieRepository _serieRepository;

    public SaveSerie(ISerieRepository serieRepository){
        _serieRepository = serieRepository;
    }
}
