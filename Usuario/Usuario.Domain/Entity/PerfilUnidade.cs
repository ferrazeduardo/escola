namespace Usuario.Domain.Entity;

public class PerfilUnidade : SeedWork.Entity
{
    public int Id { get; set; }
    public int ID_UNIDADE { get; set; }
    public Unidade Unidade { get; set; }
    public int ID_PERFIL { get; set; }
    public Perfil Perfil { get; set; }

    public ICollection<PerfilUnidadeUsuario> perfilUnidadeUsuarios { get; private set; } = [];
    public ICollection<Usuario> usuarios { get; set; } = [];
}