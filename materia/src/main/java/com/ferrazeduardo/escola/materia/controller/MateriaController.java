package com.ferrazeduardo.escola.materia.controller;

import com.ferrazeduardo.escola.materia.application.usecases.materia.save.MateriaOutput;
import com.ferrazeduardo.escola.materia.application.usecases.materia.save.SaveMateria;
import com.ferrazeduardo.escola.materia.domain.DataTransferObject.ListMateriaOutput;
import com.ferrazeduardo.escola.materia.application.usecases.materia.save.MateriaInput;
import jakarta.transaction.Transactional;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/materia")
public class MateriaController {

    public final SaveMateria saveMateria;

    public MateriaController(SaveMateria saveMateria) {
        this.saveMateria = saveMateria;
    }

    @PostMapping
    @Transactional
    public MateriaOutput SalvarMateria(@RequestBody MateriaInput materiaInput){

        var output = saveMateria.Handler(materiaInput);

        return output;
    }

    //?size=1&page=2
    //?sort=descricao
    @GetMapping
    public Page<ListMateriaOutput> ListMateria(Pageable paginacao){

        return null;
    }
}
