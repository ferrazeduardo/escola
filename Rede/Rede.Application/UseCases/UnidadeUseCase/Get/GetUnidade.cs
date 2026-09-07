using System;
using MediatR;
using Rede.Domain.Exception;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Application.UseCases.UnidadeUseCase.Get;

public class GetUnidade : IRequestHandler<GetUnidadeInput, GetUnidadeOutput>
{
    private IUnidadeRepository _unidadeRepository;

    public GetUnidade(IUnidadeRepository unidadeRepository)
    {
        _unidadeRepository = unidadeRepository;
    }

    public async Task<GetUnidadeOutput> Handle(GetUnidadeInput request, CancellationToken cancellationToken)
    {
        var unidade = await _unidadeRepository.ObterPorId(request.id);
        NotFounException.IsNull(unidade, "Unidade não encontrada");
        var output = new GetUnidadeOutput();
        output.FromEntity(unidade);
        return output;
        
    }
}
