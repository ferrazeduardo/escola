using System;

namespace Serie.Domain.Entity;

public class Unidade
{

    public Unidade()
    {

    }

    public Unidade(Guid ID_UNIDADE, String DS_UNIDADE)
    {
        setID_UNIDADE(ID_UNIDADE);
        setDS_UNIDADE(DS_UNIDADE);
    }

  
    public void setID_UNIDADE(Guid ID_UNIDADE)
    {
        this.Id = ID_UNIDADE;
    }

    public void setDS_UNIDADE(String DS_UNIDADE)
    {
        this.DS_UNIDADE = DS_UNIDADE;
    }

    public Guid Id { get; private set; }
    public String DS_UNIDADE { get; private set; }

    public ICollection<Sala> Salas { get; private set; } = [];
    public Rede Rede { get; private set; } 
    public void AddSala(Sala sala)
    {
        Salas.Add(sala);
    } 

    public void RemoveSala(Sala sala)
    {
        Salas.Remove(sala);
    }
}
