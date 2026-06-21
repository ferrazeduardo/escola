using System;
using System.Linq.Expressions;
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
        IDictionary<bool, Expression<Func<Domain.Entity.Periodo, bool>>> keys = new Dictionary<bool, Expression<Func<Domain.Entity.Periodo, bool>>>()
        {
            {request.id > 0, x => x.Id == request.id},
            {request.ano > 0, x => x.NR_ANO == request.ano}
        };

        var func = keys.FirstOrDefault(x => x.Key).Value ?? throw new ArgumentException("É nescessário enviar um argumento válido.");


        var periodo = await _periodoRepository.Get(func, false);

        NotFoundException.IsNull(periodo, "Período não encontrado");

        var GetPeriodoOutput = new GetPeriodoOutput();
        return GetPeriodoOutput.from(periodo);
    }
}
