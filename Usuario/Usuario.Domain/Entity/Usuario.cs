using System.Security.Cryptography;
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
    public byte[] SALT { get; private set; }
    public string DS_EMAIL { get; set; }

    public void SetSalt()
    {
        var salt = new byte[16];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(salt);
        SALT = salt;
    }

    public void HashSenha()
    {
        int iterations = 100_000;
        using var pbkdf2 = new Rfc2898DeriveBytes(SEG_SENHA, SALT, iterations, HashAlgorithmName.SHA256);
        var hash = pbkdf2.GetBytes(32); // 256 bits
        SEG_SENHA = Convert.ToBase64String(hash);
    }


    public ICollection<PerfilUnidadeUsuario> perfilUnidadeUsuarios { get; private set; } = [];
    public ICollection<PerfilUnidade> perfilUnidades { get; private set; } = [];
    public ICollection<Rede> redes { get; private set; } = [];
    public ICollection<UsuarioRede> usuarioRedes { get; private set; } = [];


    public void AddRede(Rede rede)
    {
        redes.Add(rede);
    }

}