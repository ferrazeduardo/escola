using System;
using Academico.Application.UseCases.Serie.Common;
using Academico.Domain.Exception;
using Academico.Domain.Interface.Repository;
using MediatR;

namespace Academico.Application.UseCases.Serie.Get;

public class GetSerie : IRequestHandler<GetSerieInput, GetSerieOutput>
{
    private ISerieRepository _serieRepository;

    public GetSerie(ISerieRepository serieRepository)
    {
        _serieRepository = serieRepository;
    }

    public async Task<GetSerieOutput> Handle(GetSerieInput request, CancellationToken cancellationToken)
    {
        var serie = await _serieRepository.Get(x => x.Id == request.id);
        NotFoundException.IsNull(serie, "Série não encontrada");

        return new GetSerieOutput
        {
            serie = new SerieModelOutput(serie.Id, serie.NR_SERIE)
        };
    }
}
