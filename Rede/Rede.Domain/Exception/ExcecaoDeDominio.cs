namespace Rede.Domain.Exception;

public class ExcecaoDeDominio : System.Exception
{
    public ExcecaoDeDominio(
        string? message
    ) : base(message)
    {
        
    }
}