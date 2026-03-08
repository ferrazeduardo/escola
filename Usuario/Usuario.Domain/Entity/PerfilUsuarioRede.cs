using System;

namespace Usuario.Domain.Entity;

public class PerfilUsuarioRede 
{
    public int ID_PERFIL { get; set; }
    public Perfil Perfil { get; set; }
    public int ID_USUARIO_REDE { get; set; }
    public UsuarioRede UsuarioRede { get; set; }
}
