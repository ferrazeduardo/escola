namespace Usuario.Domain.Entity;

public class PerfilUnidade
{
    private Guid Id { get; set; }
    private string DS_PERFIL { get; set; }
    public ICollection<Unidade> Unidades { get; private set; } = new List<Unidade>();
}