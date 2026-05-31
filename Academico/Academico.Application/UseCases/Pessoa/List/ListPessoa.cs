using System;
using Academico.Application.UseCases.Pessoa.Common;
using Academico.Domain.Exception;
using Academico.Domain.Interface.Repository;
using Academico.Domain.Interface.SearchRepository;
using MediatR;

namespace Academico.Application.UseCases.Pessoa.List;

public class ListPessoa : IRequestHandler<ListPessoaInput, ListPessoaOutput>
{
    private IPessoaRepository _pessoaRepository;

    public ListPessoa(IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }

    public async Task<ListPessoaOutput> Handle(ListPessoaInput request, CancellationToken cancellationToken)
    {
        var searchOutput = await _pessoaRepository.Search(new SearchInput(request.pagina, request.quantidade, request.pesquisa, request.ordenacao));
        List<PessoaModelOutput> pessoas = searchOutput.Itens.Select(i => new PessoaModelOutput
        {
            
        }).ToList();

        ListPessoaOutput output = new(request.pagina,request.quantidade,searchOutput.Total,pessoas);

        return output;
    }
}
