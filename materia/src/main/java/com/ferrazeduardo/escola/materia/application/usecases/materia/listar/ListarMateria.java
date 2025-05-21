package com.ferrazeduardo.escola.materia.application.usecases.materia.listar;

import com.ferrazeduardo.escola.materia.application.gateways.IMateriaRepository;

public class ListarMateria {
    private final IMateriaRepository _materiaRepository;

    public ListarMateria(IMateriaRepository materiaRepository) {
        _materiaRepository = materiaRepository;
    }

    public ListarMateriaOutput Handler(ListarMateriaInput listarMateriaInput){
       var listaMaterias = _materiaRepository.Listar(listarMateriaInput.id_rede());


        ListarMateriaOutput output = new ListarMateriaOutput();

        return output;
    }
}
