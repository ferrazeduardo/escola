using System;

namespace Serie.Domain.Entity;

public class Rede
{
    
    public ICollection<Unidade> Unidades{ get; private set; }

    public Rede(Guid idRede, String razaoSOcial) {
        setId(idRede);
        setRZ_SOCIAL(razaoSOcial);
    }


    public Rede(){}
    public Rede(Guid id){this.setId(id);}

    public Guid getId() {
        return Id;
    }

    public void setId(Guid id) {
        Id = id;
    }

    public String getRZ_SOCIAL() {
        return RZ_SOCIAL;
    }

    public void setRZ_SOCIAL(String RZ_SOCIAL) {
        this.RZ_SOCIAL = RZ_SOCIAL;
    }

    public Guid Id { get; private set; }
    public String RZ_SOCIAL { get; private set; }

    public void AddUnidadesRange(ICollection<Unidade> unidades)
    {
        this.Unidades = unidades;
    }

    public ICollection<Materia> Materias { get;  set; } = [];
    public ICollection<MateriaRede> MateriaRedes { get;  set; } = [];
  
}
