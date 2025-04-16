package com.ferrazeduardo.escola.materia.controller;

import com.ferrazeduardo.escola.materia.domain.DataTransferObject.MateriaInput;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/materia")
public class MateriaController {

    @PostMapping
    public MateriaInput SalvarMateria(@RequestBody MateriaInput materiaInput){
        return materiaInput;
    }
}
