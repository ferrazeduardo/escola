namespace Usuario.Domain.Entity;

public class Perfil : SeedWork.Entity
{
    public Perfil()
    {

    }

    public Perfil(int id, string nome)
    {
        Id = id;
        DS_PERFIL = nome;
    }

    public string DS_PERFIL { get; set; }
    public ICollection<PerfilUnidade> PerfilUnidades { get; set; } = [];
    public ICollection<Unidade> Unidades { get; set; } = [];
}