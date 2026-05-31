using System;
using Academico.Domain.Interface.SearchRepository;

namespace Academico.Application.UseCases.Pessoa.Common;

public class PaginetedListInput
{
    public PaginetedListInput(int pagina, int quantidade, string pesquisa, SearchOrder ordernacao)
    {
        this.pagina = pagina;
        this.pesquisa = pesquisa;
        this.quantidade = quantidade;
        this.ordenacao = ordenacao;   
    }

    public int pagina { get; set; }
    public int quantidade { get; set; }
    public string pesquisa { get; set; }
    public SearchOrder ordenacao { get; set; }
}
