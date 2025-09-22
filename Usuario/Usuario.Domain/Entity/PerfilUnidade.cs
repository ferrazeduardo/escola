namespace Usuario.Domain.Entity;

public class PerfilUnidade
{
    private Guid Id { get; set; }
    public ICollection<Unidade> Unidades { get; private set; } = new List<Unidade>();
    public ICollection<Perfil> Perfis { get; set; } = new List<Perfil>();
}