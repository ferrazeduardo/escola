using System;
using Academico.Application.UseCases.Pessoa.Common;
using Academico.Domain.Interface.SearchRepository;
using MediatR;

namespace Academico.Application.UseCases.Pessoa.List;

public class ListPessoaInput : PaginetedListInput, IRequest<ListPessoaOutput>
{
    public ListPessoaInput(int pagina, int quantidade, string pesquisa, SearchOrder ordernacao) : base(pagina, quantidade, pesquisa, ordernacao)
    {
    }
}
