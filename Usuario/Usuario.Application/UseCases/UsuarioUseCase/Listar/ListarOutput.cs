using System;
using Usuario.Application.UseCases.Common;
using Usuario.Application.UseCases.UsuarioUseCase.Common;

namespace Usuario.Application.UseCases.UsuarioUseCase.Listar;

public class ListarOutput : PaginetedListOutput<List<UsuarioOutput>>
{
    public ListarOutput(int pagina, int quantidade, int total, List<UsuarioOutput> items) : base(pagina, quantidade, total, items)
    {
    }
}
