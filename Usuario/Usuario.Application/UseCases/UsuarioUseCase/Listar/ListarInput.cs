using System;
using MediatR;
using Usuario.Application.UseCases.Common;
using Usuario.Domain.Interface.SearchRepository;

namespace Usuario.Application.UseCases.UsuarioUseCase.Listar;

public class ListarInput : PaginetedListInput, IRequest<ListarOutput>
{
    public ListarInput(int pagina, int quantidade, string pesquisa, string ordernadacao, SearchOrder order) : base(pagina, quantidade, pesquisa, ordernadacao, order)
    {
    }

}
