package com.ferrazeduardo.escola.materia.controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/materia")
public class MateriaController {

    @GetMapping
    public String SalvarMateria(){
        return "Materia Salva java";
    }
}
