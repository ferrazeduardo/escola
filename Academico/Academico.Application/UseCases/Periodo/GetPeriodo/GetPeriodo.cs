using System;
using Academico.Domain.Exception;
using Academico.Domain.Interface.Repository;
using MediatR;

namespace Academico.Application.UseCases.Periodo.GetPeriodo;

public class GetPeriodo : IRequestHandler<GetPeriodoInput, GetPeriodoOutput>
{
    private IPeriodoRepository _periodoRepository;

    public GetPeriodo(IPeriodoRepository periodoRepository)
    {
        _periodoRepository = periodoRepository;
    }
    public async Task<GetPeriodoOutput> Handle(GetPeriodoInput request, CancellationToken cancellationToken)
    {
        var periodo = await _periodoRepository.Get(x => x.Id == request.id);

        NotFoundException.IsNull(periodo, "Período não encontrado");

        var GetPeriodoOutput = new GetPeriodoOutput();
        return GetPeriodoOutput.from(periodo);
    }
}
