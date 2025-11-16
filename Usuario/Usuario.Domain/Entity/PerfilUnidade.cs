namespace Usuario.Domain.Entity;

public class PerfilUnidade : SeedWork.Entity
{
    public int ID_UNIDADE { get; set; }
    public Unidade Unidade { get; set; }
    public int ID_PERFIL { get; set; }
    public Perfil Perfil { get; set; }
}