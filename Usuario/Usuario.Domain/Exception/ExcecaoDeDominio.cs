namespace Usuario.Domain.Exception;

public class ExcecaoDeDominio : System.Exception
{
    public string Mensagem { get; set; }

    public ExcecaoDeDominio(string mensagem) : base(mensagem)
    {
        
    }
    

    public void HaError(bool temErro, string mensagem)
    {
        if (temErro)
            throw new System.Exception(mensagem);
    }
}