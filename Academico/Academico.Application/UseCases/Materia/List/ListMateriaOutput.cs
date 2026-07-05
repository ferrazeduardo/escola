using System;
using Academico.Application.UseCases.Common;
using Academico.Application.UseCases.Materia.Common;

namespace Academico.Application.UseCases.Materia.List;

public class ListMateriaOutput : PaginetedListOutput<List<MateriaModelOutput>>
{
    public ListMateriaOutput(int pagina, int quantidade, int total, List<MateriaModelOutput> items) : base(pagina, quantidade, total, items)
    {
    }
}
