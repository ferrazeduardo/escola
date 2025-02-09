using Rede.Domain.Exception;

namespace Rede.Domain.Validation;

public class ValidacaoDominio
{
    public static (bool response, string mensagem) EhNull(object? target, string nomeCampo)
    {
        if (target is null)
           return (true, $"O campo {nomeCampo} deveria ser nulo");

        return (false, String.Empty);
    }

    public static (bool response, string mensagem) CampoVazio(string target, string nomeCampo)
    {
        if (target == string.Empty)
            return (true, $"O campo {nomeCampo} tem que ser preenchido");

        return (false, String.Empty);
    }
    

    public static (bool response, string mensagem) MinLength(string target, int minLength, string nomeCampo)
    {
        if (target.Length < minLength)
            return (true,$"O campo {nomeCampo} tem que ter ao menos {minLength} caracteres");
        
        return (false, String.Empty);
    }
    public static (bool response, string mensagem) MaxLength(string target, int maxLength, string nomeCampo)
    {
        if (target.Length > maxLength)
            return (true,$"O campo {nomeCampo} tem que ter menos de {maxLength} caracteres");
        
        return (false, String.Empty);
    }
}