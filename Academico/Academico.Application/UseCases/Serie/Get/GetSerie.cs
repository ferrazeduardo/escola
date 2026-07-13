using System;
using Academico.Application.UseCases.Serie.Common;
using Academico.Domain.Exception;
using Academico.Domain.Interface.Repository;
using AppDomain = Academico.Domain.Entity;
using MediatR;

namespace Academico.Application.UseCases.Serie.Get;

public class GetSerie : IRequestHandler<GetSerieInput, GetSerieOutput>
{
    private ISerieRepository _serieRepository;
    private IPeriodoRepository _periodoRepository;
    private IMateriaRepository _materiaRepository;

    public GetSerie(ISerieRepository serieRepository, IPeriodoRepository periodoRepository, IMateriaRepository materiaRepository)
    {
        _serieRepository = serieRepository;
        _periodoRepository = periodoRepository;
        _materiaRepository = materiaRepository;
    }

    public async Task<GetSerieOutput> Handle(GetSerieInput request, CancellationToken cancellationToken)
    {
        var serie = await _serieRepository.Get(x => x.Id == request.id && x.redeId == request.redeId);
        NotFoundException.IsNull(serie, "Série não encontrada");


        List<AppDomain.Materia> materias = null;
        if (serie.materiasId is not null && serie.materiasId.Count > 0)
            materias = await _materiaRepository.ListByIds(serie.materiasId);


        AppDomain.Periodo periodo = null;
        if (serie.periodosId > 0)
            periodo = await _periodoRepository.Get(x => x.Id == serie.periodosId);

        return new GetSerieOutput
        {
            serie = new SerieModelOutput(serie.Id, serie.NR_SERIE, serie.nrSala, materias, periodo?.NR_ANO ?? 0)
        };
    }
}
