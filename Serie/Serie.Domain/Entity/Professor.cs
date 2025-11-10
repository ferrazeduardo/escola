using System;

namespace Serie.Domain.Entity;

public class Professor : SeedWorks.Entity
{
    public Professor(Guid id, String nome, ICollection<Materia> materia)
    {
        this.setId(id);
        this.nome = nome;
        this.materia = materia;
    }

    public String getNome()
    {
        return nome;
    }

    public ICollection<Materia> getMateria()
    {
        return materia;
    }

    public String nome { get; private set; }
    public ICollection<Materia> materia { get; private set; } = [];

}
