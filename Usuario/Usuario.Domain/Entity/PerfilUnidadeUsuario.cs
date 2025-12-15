using System;

namespace Usuario.Domain.Entity;

public class PerfilUnidadeUsuario
{
    public int ID_PERFIL_UNIDADE { get; set; }
    public PerfilUnidade PerfilUnidade { get; set; }
    public int ID_USUARIO { get; set; }
    public Usuario Usuario { get; set; }
}
