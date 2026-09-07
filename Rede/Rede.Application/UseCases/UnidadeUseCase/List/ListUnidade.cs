using System;
using MediatR;
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
        throw new NotImplementedException();
    }
}
