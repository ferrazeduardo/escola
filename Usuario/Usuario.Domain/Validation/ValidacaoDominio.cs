using Usuario.Domain.Exception;

namespace Usuario.Domain.Validation;

public class ValidacaoDominio
{
    public static void EhNull(object? target, string nomeCampo)
    {
        if (target is null)
            throw new ExcecaoDeDominio( $"O campo {nomeCampo} deveria ser nulo");

    }

    public static void CampoVazio(string target, string nomeCampo)
    {
        if (target == string.Empty)
            throw new ExcecaoDeDominio($"O campo {nomeCampo} tem que ser preenchido");

    }
    

    public static void MinLength(string target, int minLength, string nomeCampo)
    {
        if (target.Length < minLength)
            throw new ExcecaoDeDominio($"O campo {nomeCampo} tem que ter ao menos {minLength} caracteres");
        
    }
    public static void MaxLength(string target, int maxLength, string nomeCampo)
    {
        if (target.Length > maxLength)
            throw new ExcecaoDeDominio($"O campo {nomeCampo} tem que ter menos de {maxLength} caracteres");
        
    }

    public static void Quando(bool condicao, string mensagem)
    {
        if(condicao)
            throw new ExcecaoDeDominio(mensagem);
    }
}