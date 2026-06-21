using System;
using Academico.Domain.Exception;
using Academico.Domain.Interface.Repository;
using MediatR;

namespace Academico.Application.UseCases.Periodo.List;

public class ListPeriodo : IRequestHandler<ListPeriodoInput, ListPeriodoOutput>
{
    private IPeriodoRepository _periodoRepository;

    public ListPeriodo(IPeriodoRepository periodoRepository)
    {
        _periodoRepository = periodoRepository;
    }
    public async Task<ListPeriodoOutput> Handle(ListPeriodoInput request, CancellationToken cancellationToken)
    {
        var periodos = await _periodoRepository.ListAll(request.anoInicio, request.anoFim);
        NotFoundException.CountZero(periodos,"Períodos não encontrados.");

        ListPeriodoOutput output = new();
        output.periodos = periodos.Select(p => new Common.PeriodoModelOuput
        {
            id = p.Id,
            dataFim = p.DT_FIM,
            dataInicio = p.DT_INICIO,
            status = p.ST_PERIODO
        }).ToList();

        return output;
    }
}
