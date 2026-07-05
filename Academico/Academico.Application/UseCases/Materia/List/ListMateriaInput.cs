using Academico.Application.UseCases.Pessoa.Common;
using Academico.Domain.Interface.SearchRepository;
using MediatR;

namespace Academico.Application.UseCases.Materia.List;

public  class ListMateriaInput : PaginetedListInput, IRequest<ListMateriaOutput>
{
    public ListMateriaInput(int pagina, int quantidade, string pesquisa, SearchOrder ordernacao) : base(pagina, quantidade, pesquisa, ordernacao)
    {
    }
}