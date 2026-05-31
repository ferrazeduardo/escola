using System;

namespace Academico.Domain.Interface.SearchRepository;

public class SearchInput
{
    public SearchInput(int pagina, int quantidade, string pesquisa, SearchOrder ordernacao)
    {
        Pagina = pagina;
        Quantidade = quantidade;
        Pesquisa = pesquisa;
        Ordernacao = ordernacao;
    }

    public int Pagina { get; set; }
    public int Quantidade { get; set; }
    public string Pesquisa { get; set; }
    public SearchOrder Ordernacao { get; set; }
}
