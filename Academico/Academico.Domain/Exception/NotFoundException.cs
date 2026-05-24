using System;

namespace Academico.Domain.Exception;

public class NotFoundException : System.Exception
{
    public NotFoundException(string mensagem) : base(mensagem)
    {

    }


    public static void IsNull(object? @object, string mensagem)
    {
        if (@object is null)
            throw new NotFoundException(mensagem);
    }
}
