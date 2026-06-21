using System;

namespace Academico.Domain.Exception;

public class AlreadyExistsException : System.Exception
{
    public AlreadyExistsException(string mensagem) : base(mensagem)
    {

    }

    public static void IsNotNull(string entityNome, object @object, object key)
    {
        if (@object != null)
            throw new AlreadyExistsException($"{entityNome} com identificador {key} já existe");
    }
    
}
