using Usuario.Domain.Validation;

namespace Usuario.Domain.Entity;

public class Perfil : SeedWork.Entity
{
    public Perfil()
    {

    }

    public Perfil(string nome)
    {
        DS_PERFIL = nome;
        Validacao();
    }


    public void Validacao()
    {
        ValidadorDeRegra.Novo()
        .Quando(DS_PERFIL.Length > 50, "")
        .DispararExcecaoSeExistir();
    }

    public string DS_PERFIL { get; set; }
    public ICollection<PerfilUsuarioRede> perfilUsuarioRedes { get; set; } = [];
    public ICollection<UsuarioRede> usuarioRedes { get; set; } = [];
}