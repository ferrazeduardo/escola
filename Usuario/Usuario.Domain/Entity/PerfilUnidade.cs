namespace Usuario.Domain.Entity;

public class PerfilUnidade : SeedWork.Entity
{
    public int id_unidade { get; set; }
    public Unidade Unidade { get; set; }
    public int id_perfil { get; set; }
    public Perfil Perfil { get; set; }
}