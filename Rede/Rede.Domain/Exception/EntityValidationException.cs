namespace Rede.Domain.Exception;

public class EntityValidationException : System.Exception
{
    public EntityValidationException(
        string? message
    ) : base(message)
    {
        
    }
}