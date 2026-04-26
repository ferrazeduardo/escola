using Usuario.Domain.SeedWork;
using Usuario.Domain.Validation;

namespace Usuario.Domain.Entity;

public class Perfil : AggregationRoot
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
        .Quando(string.IsNullOrEmpty(DS_PERFIL), "descrição do perfil é obrigatória")
        .Quando(DS_PERFIL.Length > 50, "descrição do perfil deve ter no máximo 50 caracteres")
        .DispararExcecaoSeExistir();
    }

    public void Update(string descricao)
    {
        DS_PERFIL = descricao;
        Validacao();
    }

    public string DS_PERFIL { get; set; }
}