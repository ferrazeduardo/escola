using Academico.Domain.Entity;
using Academico.Domain.Exception;
using Academico.Domain.Interface;
using Academico.Domain.Interface.Repository;
using MediatR;

namespace Academico.Application.UseCases.Serie.BindSeriePeriodoUnidade;

public class BindSeriePeriodoUnidade : IRequestHandler<BindSeriePeriodoUnidadeInput, BindSeriePeriodoUnidadeOutput>
{
    private IUnitOfWork _unitOfWork;
    private ISerieRepository _serieRepository;
    private ISeriePeriodoUnidadeRepository _seriePeriodoUnidadeRepository;

    public BindSeriePeriodoUnidade(IUnitOfWork unitOfWork, ISerieRepository serieRepository,ISeriePeriodoUnidadeRepository seriePeriodoUnidadeRepository)
    {
        _unitOfWork = unitOfWork;
        _serieRepository = serieRepository;
        _seriePeriodoUnidadeRepository = seriePeriodoUnidadeRepository;
    }

    public async Task<BindSeriePeriodoUnidadeOutput> Handle(BindSeriePeriodoUnidadeInput request, CancellationToken cancellationToken)
    {
        var serie = await _serieRepository.Get(x => x.Id == request.serieId);
        NotFoundException.IsNull(serie, "Serie não existe");

        var seriePeriodoUnidadeExistente = await _seriePeriodoUnidadeRepository.Get(x => x.ID_Serie == request.serieId && x.ID_Periodo == request.periodo && x.ID_UNIDADE == request.unidadeId);
        ExcecaoDeDominio.HaError(seriePeriodoUnidadeExistente is not null, "Série já vinculada a este período e unidade");

        SeriePeriodoUnidade seriePeriodoUnidade = new()
        {
            ID_Serie = request.serieId,
            ID_Periodo = request.periodo,
            ID_UNIDADE = request.unidadeId
        };
        await _seriePeriodoUnidadeRepository.Cadastrar(seriePeriodoUnidade, cancellationToken);

        await _unitOfWork.Commit(cancellationToken);

        return new BindSeriePeriodoUnidadeOutput();
    }
}
