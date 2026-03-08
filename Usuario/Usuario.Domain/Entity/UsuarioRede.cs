using System;

namespace Usuario.Domain.Entity;

public class UsuarioRede : SeedWork.Entity
{
    public int ID_USUARIO { get; set; }
    public Usuario usuario { get; set; }
    public int ID_REDE { get; set; }
    public Rede rede { get; set; }

    public List<PerfilUsuarioRede> perfilUsuarioRedes { get; set; }
    public List<Perfil> perfis { get; set; }
}
