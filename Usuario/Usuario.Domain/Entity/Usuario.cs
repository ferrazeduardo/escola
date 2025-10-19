using Usuario.Domain.Validation;

namespace Usuario.Domain.Entity;

public class Usuario : SeedWork.Entity
{
    public Usuario(string nmUsuario, DateTime dtNascimento, string nrCpf, string dsEmail, string segSenha)
    {
        NM_USUARIO = nmUsuario;
        DT_NASCIMENTO = dtNascimento;
        NR_CPF = nrCpf;
        DS_EMAIL = dsEmail;
        SEG_SENHA = segSenha;
        ValidacaoCreate();
    }

    public Usuario()
    {

    }

    public void ValidacaoCreate()
    {
        ValidadorDeRegra.Novo()
        .Quando(string.IsNullOrEmpty(NM_USUARIO), "Nome usuário obrigatório")
        .Quando(NM_USUARIO.Length > 100, "Nome de usuário não pode ter mais de 100 caracteres")
        .Quando(DT_NASCIMENTO < new DateTime(1900, 1, 1), "Data de nascimento inválido")
        .Quando(NR_CPF.Length != 11, "Cpf tem que possuir 11 digitos")
        .Quando(string.IsNullOrEmpty(DS_EMAIL), "Email é obrigatorio")
        .Quando(DS_EMAIL.Length > 50, "Email não pode ter mais de 50 caracteres")
        .Quando(DS_EMAIL.Contains("@") is false, "Está faltando o @ no email")
        .DispararExcecaoSeExistir();
    }

    public string NM_USUARIO { get; private set; }
    public DateTime DT_NASCIMENTO { get; private set; }
    public string NR_CPF { get; private set; }
    public string SEG_SENHA { get; private set; }
    public string SALT { get; private set; }
    public string DS_EMAIL { get; set; }

    public void SetSalt(string salt)
    {
        SALT = salt;
    }

    public List<Unidade> Unidades { get; set; }

}