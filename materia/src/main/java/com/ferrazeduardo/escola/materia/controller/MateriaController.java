package com.ferrazeduardo.escola.materia.controller;

import com.ferrazeduardo.escola.materia.domain.DataTransferObject.MateriaInput;
import jakarta.transaction.Transactional;
import jakarta.validation.Valid;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/materia")
public class MateriaController {

    @PostMapping
    @Transactional
    public MateriaInput SalvarMateria(@RequestBody @Valid MateriaInput materiaInput){
        return materiaInput;
    }
}
