using Pessoa.Domain.Exception;

namespace Pessoa.Domain.Validation;

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

    public static void TodosNumerosIguais(string numero,string nomeCampo)
    {
        if (numero.Distinct().Count() == 1)
            throw new ExcecaoDeDominio($"O campo {nomeCampo} possui números iguais");
    }
    
    public static bool ValidarCPF(string cpf)
    {
        cpf = new string(cpf.Where(char.IsDigit).ToArray());

         if (cpf.Length != 11)
             throw new ExcecaoDeDominio("Número de digitos diferente de 11");
        
         if (cpf.Distinct().Count() == 1)
             throw new ExcecaoDeDominio("Todos os números são iguais");

        int[] pesos = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int primeiroDigito = CalcularDigito(cpf.Substring(0, 9), pesos);

        pesos = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int segundoDigito = CalcularDigito(cpf.Substring(0, 10), pesos);

        if(cpf[9] == primeiroDigito + '0' && cpf[10] == segundoDigito + '0')
            return true;
        
        throw new ExcecaoDeDominio("Cpf inválido");
    }

    private static int CalcularDigito(string cpfParcial, int[] pesos)
    {
        int soma = 0;
        for (int i = 0; i < cpfParcial.Length; i++)
        {
            soma += (cpfParcial[i] - '0') * pesos[i];
        }

        int resto = soma % 11;
        return resto < 2 ? 0 : 11 - resto;
    }
}