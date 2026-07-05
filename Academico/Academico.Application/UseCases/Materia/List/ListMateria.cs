using System;
using Academico.Application.UseCases.Materia.Common;
using Academico.Domain.Exception;
using Academico.Domain.Interface.Repository;
using Academico.Domain.Interface.SearchRepository;
using MediatR;

namespace Academico.Application.UseCases.Materia.List;

public class ListMateria : IRequestHandler<ListMateriaInput, ListMateriaOutput>
{
    private IMateriaRepository _materiaRepository;

    public ListMateria(IMateriaRepository materiaRepository)
    {
        _materiaRepository = materiaRepository;
    }

    public  async Task<ListMateriaOutput> Handle(ListMateriaInput request, CancellationToken cancellationToken)
    {
        var search = await _materiaRepository.Search(new SearchInput(request.pagina,request.quantidade, null, request.ordenacao));

        NotFoundException.IsNull(search, "Nenhuma Matéria Encontrada");

        return new ListMateriaOutput(search.paginaAtual, search.Quantidade,search.Total, search.Itens.Select(x => new MateriaModelOutput
        {
            id = x.Id,
            descricao = x.DS_MATERIA,
            status = x.ST_MATERIA
        }).ToList());
    }
}
