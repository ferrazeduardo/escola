using System;

namespace Usuario.Domain.Entity;

public class PerfilPermissao
{
    public PerfilPermissao()
    {
        
    }

    public PerfilPermissao(int id_perfil, int id_permissao)
    {
        this.ID_PERFIL = id_perfil;
        this.ID_PERMISSAO = id_permissao;
    }

    public int ID_PERFIL { get; private set; }
    public int ID_PERMISSAO { get; private set; }
}
