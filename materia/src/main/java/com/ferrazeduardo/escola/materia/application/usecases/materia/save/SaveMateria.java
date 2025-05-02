package com.ferrazeduardo.escola.materia.application.usecases.materia.save;

import com.ferrazeduardo.escola.materia.domain.Entity.Materia;
import com.ferrazeduardo.escola.materia.application.gateways.IMateriaRepository;

public class SaveMateria {

    private final IMateriaRepository _materiaRepository;

    public SaveMateria(IMateriaRepository materiaRepository) {
        _materiaRepository = materiaRepository;
    }


    public MateriaOutput Handler(MateriaInput materiaInput){
        Materia materia = new Materia(materiaInput.id_rede(), materiaInput.descricao());

        _materiaRepository.Inserir(materia);

        MateriaOutput materiaOutput = new MateriaOutput(materia.getId());

        return materiaOutput;
    }
}
