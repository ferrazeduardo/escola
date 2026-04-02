using System;
using Usuario.Domain.Interface.SearchRepository;

namespace Usuario.Application.UseCases.Common;

public class PaginetedListInput
{
    public PaginetedListInput(int pagina, int quantidade, string pesquisa, string ordernadacao, SearchOrder order)
    {
        this.pagina = pagina;
        this.quantidade = quantidade;
        this.pesquisa = pesquisa;
        this.ordernadacao = ordernadacao;
        this.order = order;
    }

    public int pagina { get; set; }
    public int quantidade { get; set; }
    public string pesquisa { get; set; }
    public string ordernadacao { get; set; }
    public SearchOrder order { get; set; }
}
