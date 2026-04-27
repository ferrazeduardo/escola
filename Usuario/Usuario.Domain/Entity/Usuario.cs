using System.Security.Cryptography;
using Usuario.Domain.Exception;
using Usuario.Domain.SeedWork;
using Usuario.Domain.Validation;

namespace Usuario.Domain.Entity;

public class Usuario : AggregationRoot
{
    public Usuario(string nmUsuario, DateTime dtNascimento, string nrCpf, string dsEmail, string segSenha)
    {
        NM_USUARIO = nmUsuario;
        DT_NASCIMENTO = DateTime.SpecifyKind(dtNascimento, DateTimeKind.Utc);
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

    public string HashSenha(string senha)
    {
        int iterations = 100_000;
        using var pbkdf2 = new Rfc2898DeriveBytes(senha, SALT, iterations, HashAlgorithmName.SHA256);
        var hash = pbkdf2.GetBytes(32); // 256 bits
        return Convert.ToBase64String(hash);
    }

    public void SetSenhaCriptografada()
    {
        SetSalt();
        SEG_SENHA = HashSenha(SEG_SENHA);
    }

    public void VerificarSenha(string senhaDigitada)
    {

        var hashDigitado = Convert.FromBase64String(HashSenha(senhaDigitada));

        var hashSalvo = Convert.FromBase64String(SEG_SENHA);

        var senhaCriptografada = CryptographicOperations.FixedTimeEquals(
            hashDigitado,
            hashSalvo);

        ExcecaoDeDominio.HaError(senhaCriptografada is false, "Senha esta inválida");
    }


    List<(int redeId, int perfilId)> redeIdPerfilId = [];
    public List<PerfilUsuarioRede> perfilUsuarioRedes { get; set; } = [];


    public void AddPerfilUsuarioRede(int redeId, int perfilId)
    {
        perfilUsuarioRedes.Add(new PerfilUsuarioRede
        {
            ID_PERFIL = perfilId,
            ID_REDE = redeId,
            ID_USUARIO = Id
        });
    }

    public void Update(string nome, string cpf)
    {
        ValidacaoUpdate(nome, cpf);
        NM_USUARIO = string.IsNullOrEmpty(nome) ? NM_USUARIO : nome;
        NR_CPF = string.IsNullOrEmpty(cpf.Replace(".", "").Replace("-", "")) ? NR_CPF : cpf;
    }


    public void ValidacaoUpdate(string nome, string cpf)
    {
        ValidadorDeRegra.Novo()
        .Quando(nome.Length > 100, "Nome não pode ter mais de 100 caracteres")
        .Quando(cpf.Replace(".", "").Replace("-", "").Length > 11, "Cpf não pode ter mais de 11 caracteres")
        .DispararExcecaoSeExistir();
    }
}