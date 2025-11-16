using System;

namespace Serie.Domain.Entity;

public class Professor : SeedWorks.Entity
{
    public Professor(Guid id, String nome, ICollection<Materia> materia)
    {
        this.setId(id);
        this.NM_PROFESSOR = nome;
        this.Materias = materia;
    }

    public String getNome()
    {
        return NM_PROFESSOR;
    }

    public ICollection<Materia> getMateria()
    {
        return Materias;
    }

    public String NM_PROFESSOR { get; private set; }
    public ICollection<Materia> Materias { get; private set; } = [];

}
