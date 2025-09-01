package com.ferrazeduardo.escola.Serie.application.usecase.materia.save;

import com.ferrazeduardo.escola.Serie.application.gateways.IMateriaRepository;
import com.ferrazeduardo.escola.Serie.domain.entities.Materia;

public class SaveMateria {
    private IMateriaRepository _materiaRepository;
    public SaveMateria(IMateriaRepository materiaRepository){
         _materiaRepository = materiaRepository;
    }

    public SaveMateriaOutput Handler(SaveMateriaInput saveMateriaInput){

        Materia materia = new Materia(saveMateriaInput.idRede(), saveMateriaInput.descricaoMateria());
        _materiaRepository.Inserir(materia);
        return new SaveMateriaOutput();
    }
}
