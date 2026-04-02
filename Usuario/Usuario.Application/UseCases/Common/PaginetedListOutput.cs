using System;

namespace Usuario.Application.UseCases.Common;

public class PaginetedListOutput<TOutput>
{
    public PaginetedListOutput(int pagina, int quantidade, int total, TOutput items)
    {
        this.pagina = pagina;
        this.quantidade = quantidade;
        this.total = total;
        Items = items;
    }

    public int pagina { get; set; }
    public int quantidade { get; set; }
    public int total { get; set; }
    public TOutput Items { get; set; }
}
