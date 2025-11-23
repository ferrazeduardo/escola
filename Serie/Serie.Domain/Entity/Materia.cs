using System;
using Serie.Domain.Validator;

namespace Serie.Domain.Entity;

public class Materia : SeedWorks.Entity
{
    public String ST_MATERIA{ get; private set; }

   
    public String DS_MATERIA{ get; private set; }

    public ICollection<Rede> Rede { get; private set; } = [];
    public ICollection<Professor> Professor { get; private set; } = [];
    public ICollection<Aula> Aulas { get; private set; } = [];

    public Materia( String DS_MATERIA,Rede rede) {
        this.DS_MATERIA = DS_MATERIA;
        this.Rede.Add(rede);
        MateriaAtiva();
        Validacoes();
    }



    public Materia(){

    }

  
    public String getST_MATERIA() {
        return ST_MATERIA;
    }


    public String getDS_MATERIA() {
        return DS_MATERIA;
    }



    public void MateriaAtiva(){
        ST_MATERIA = "S";
    }


    public void MateriaDesativada(){
        ST_MATERIA = "N";
    }



    public void Validacoes(){

        ValidadorDeRegra.Novo()
        .Quando(DS_MATERIA == null, "descrição da matéria não pode ser nulo")
        .Quando(DS_MATERIA.Length > 50, "descrição da matéria não pode ter mais de 50 caracteres")
        .Quando(DS_MATERIA.Length == 0, "por favor, informar descrição da materia")
        .DispararQuandoExistirErro();

    }
}
