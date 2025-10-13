namespace Usuario.Domain.Entity;

public class Unidade : SeedWork.Entity
{
    public Unidade(int id, string nome)
    {
        DS_UNIDADE = nome;
        Id = id;
    }
    public Unidade()
    {

    }
    public string DS_UNIDADE { get; private set; }

    public ICollection<Perfil> Perfis { get; private set; } = [];
}