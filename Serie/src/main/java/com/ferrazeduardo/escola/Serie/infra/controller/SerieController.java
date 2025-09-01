package com.ferrazeduardo.escola.Serie.infra.controller;


import com.ferrazeduardo.escola.Serie.application.usecase.serie.save.SaveSerie;
import com.ferrazeduardo.escola.Serie.application.usecase.serie.save.SerieInput;
import com.ferrazeduardo.escola.Serie.application.usecase.serie.save.SerieOutput;
import jakarta.transaction.Transactional;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/serie")
public class SerieController {

    private SaveSerie _saveSerie;
    public SerieController(SaveSerie saveSerie){
        _saveSerie = saveSerie;
    }


    @PostMapping("/salvar")
    @Transactional
    public SerieOutput SalvarSerie(@RequestBody SerieInput serieInput){
        var response = _saveSerie.Handler(serieInput);
        return response;
    }
}
