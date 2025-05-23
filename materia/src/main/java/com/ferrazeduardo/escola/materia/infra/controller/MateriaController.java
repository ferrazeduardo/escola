package com.ferrazeduardo.escola.materia.infra.controller;

import com.ferrazeduardo.escola.materia.application.usecases.materia.listar.ListarMateria;
import com.ferrazeduardo.escola.materia.application.usecases.materia.listar.ListarMateriaInput;
import com.ferrazeduardo.escola.materia.application.usecases.materia.listar.ListarMateriaOutput;
import com.ferrazeduardo.escola.materia.application.usecases.materia.save.MateriaOutput;
import com.ferrazeduardo.escola.materia.application.usecases.materia.save.SaveMateria;
import com.ferrazeduardo.escola.materia.application.usecases.materia.save.MateriaInput;
import jakarta.transaction.Transactional;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/materia")
public class MateriaController {

    public final SaveMateria saveMateria;
    public final ListarMateria listarMateria;

    public MateriaController(SaveMateria saveMateria,ListarMateria listarMateria) {

        this.saveMateria = saveMateria;
        this.listarMateria = listarMateria;
    }

    @PostMapping("/salvar")
    @Transactional
    public MateriaOutput SalvarMateria(@RequestBody MateriaInput materiaInput){

        var output = saveMateria.Handler(materiaInput);

        return output;
    }

    @PostMapping("/listar")
    public ListarMateriaOutput ListMateria(@RequestBody ListarMateriaInput listarMateriaInput){

        return listarMateria.Handler(listarMateriaInput);
    }
}
