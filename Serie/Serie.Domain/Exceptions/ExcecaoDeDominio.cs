using System;

namespace Serie.Domain.Exceptions;

public class ExcecaoDeDominio : Exception
{
    public ExcecaoDeDominio(String mensagem) : base(mensagem)
    {

    }

    public ExcecaoDeDominio()
    {
        
    }
    
    public void HaError(bool erro,String mensagem)
    {
        if (erro)
            throw new ExcecaoDeDominio(mensagem);
    }
}
