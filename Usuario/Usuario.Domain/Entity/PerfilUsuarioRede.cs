using System;

namespace Usuario.Domain.Entity;

public class PerfilUsuarioRede
{
    public int ID_PERFIL { get; set; }
    public Perfil Perfil { get; set; }
    public int ID_USUARIO { get; set; }
    public Usuario Usuario { get; set; }
    public int ID_REDE { get; set; }
    public Rede Rede { get; set; }
}
