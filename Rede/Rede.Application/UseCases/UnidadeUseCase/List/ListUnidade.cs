using System;
using MediatR;
using Rede.Domain.Exception;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Application.UseCases.UnidadeUseCase.List;

public class ListUnidade : IRequestHandler<ListUnidadeInput, ListUnidadeOutput>
{
    private IUnidadeRepository _unidadeRepository;

    public ListUnidade(IUnidadeRepository unidadeRepository)
    {
        _unidadeRepository = unidadeRepository;
    }
    public async Task<ListUnidadeOutput> Handle(ListUnidadeInput request, CancellationToken cancellationToken)
    {
       var unidades = await _unidadeRepository.ListarTodosPorRede(request.id_rede);
       NotFounException.IsNull(unidades, "Nenhuma unidade encontrada");

       var output = new ListUnidadeOutput();
         output.FromEntity(unidades);
         return output;
    }
}
