using System;
using Academico.Application.UseCases.Common;
using Academico.Application.UseCases.Pessoa.Common;

namespace Academico.Application.UseCases.Pessoa.List;

public class ListPessoaOutput : PaginetedListOutput<List<PessoaModelOutput>>
{
    public ListPessoaOutput(int pagina, int quantidade, int total, List<PessoaModelOutput> items) : base(pagina, quantidade, total, items)
    {
    }
}
