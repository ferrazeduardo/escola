using System;

namespace Rede.Domain.Exception;

public class NotFounException : IOException
{
    public NotFounException(string mensagem) : base(mensagem)
    {
    }

    public static void Object(object obj, string mensagem)
    {
        if (obj is null)
            throw new NotFounException(mensagem);
    }

    public static void List(List<object> list, string mensagem)
    {
        if (list.Count == 0)
            throw new NotFounException(mensagem);
    }
}
