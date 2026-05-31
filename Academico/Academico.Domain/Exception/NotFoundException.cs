using System;
using Academico.Domain.Entity;

namespace Academico.Domain.Exception;

public class NotFoundException : System.Exception
{
    public NotFoundException(string mensagem) : base(mensagem)
    {

    }

    public static void CountZero<T>(List<T> @object, string mensagem)
    {
        if (@object is null || @object.Count == 0)
            throw new NotFoundException(mensagem);
    }

    public static void IsNull(object? @object, string mensagem)
    {
        if (@object is null)
            throw new NotFoundException(mensagem);
    }
}
