package com.ferrazeduardo.escola.materia.controller;
import java.util.List;

import com.ferrazeduardo.escola.materia.domain.DataTransferObject.ListMateriaOutput;
import com.ferrazeduardo.escola.materia.domain.DataTransferObject.MateriaInput;
import jakarta.transaction.Transactional;
import jakarta.validation.Valid;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;

@RestController
@RequestMapping("/materia")
public class MateriaController {

    @PostMapping
    @Transactional
    public MateriaInput SalvarMateria(@RequestBody @Valid MateriaInput materiaInput){
        return materiaInput;
    }

    //?size=1&page=2
    //?sort=descricao
    @GetMapping
    public Page<ListMateriaOutput> ListMateria(Pageable paginacao){

        return null;
    }
}
