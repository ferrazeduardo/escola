namespace Rede.Api.Filters;

public class GraphqlErrorFilter : IErrorFilter
{
    public IError OnError(IError error)
    {
        return error.WithMessage(error?.Exception?.Message ?? "Erro inesperado");
    }
}