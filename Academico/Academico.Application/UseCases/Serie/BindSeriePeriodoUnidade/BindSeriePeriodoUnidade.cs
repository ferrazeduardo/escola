using Academico.Domain.Entity;
using Academico.Domain.Exception;
using Academico.Domain.Interface;
using Academico.Domain.Interface.HttpClients;
using Academico.Domain.Interface.Repository;
using MediatR;

namespace Academico.Application.UseCases.Serie.BindSeriePeriodoUnidade;

public class BindSeriePeriodoUnidade : IRequestHandler<BindSeriePeriodoUnidadeInput, BindSeriePeriodoUnidadeOutput>
{
    private IUnitOfWork _unitOfWork;
    private ISerieRepository _serieRepository;
    private ISeriePeriodoUnidadeRepository _seriePeriodoUnidadeRepository;
    private IUnidadeClient _unidadeClient;

    public BindSeriePeriodoUnidade(IUnitOfWork unitOfWork, ISerieRepository serieRepository,ISeriePeriodoUnidadeRepository seriePeriodoUnidadeRepository,IUnidadeClient unidadeClient)
    {
        _unitOfWork = unitOfWork;
        _serieRepository = serieRepository;
        _seriePeriodoUnidadeRepository = seriePeriodoUnidadeRepository;
        _unidadeClient = unidadeClient;
    }

    public async Task<BindSeriePeriodoUnidadeOutput> Handle(BindSeriePeriodoUnidadeInput request, CancellationToken cancellationToken)
    {
        var serie = await _serieRepository.Get(x => x.Id == request.serieId);
        NotFoundException.IsNull(serie, "Serie não existe");

        var unidade = await _unidadeClient.Obter(request.unidadeId);
        NotFoundException.IsNull(unidade, "Unidade não existe");
        unidade.SalaNaoVinculada(request.numeroSala);

        var seriePeriodoUnidadeExistente = await _seriePeriodoUnidadeRepository.Get(x => x.ID_Serie == request.serieId && x.ID_Periodo == request.periodo && x.ID_UNIDADE == request.unidadeId);
        ExcecaoDeDominio.HaError(seriePeriodoUnidadeExistente is not null, "Série já vinculada a este período e unidade");

        SeriePeriodoUnidade seriePeriodoUnidade = new()
        {
            ID_Serie = request.serieId,
            ID_Periodo = request.periodo,
            ID_UNIDADE = request.unidadeId,
            NR_SALA = request.numeroSala
        };
        await _seriePeriodoUnidadeRepository.Cadastrar(seriePeriodoUnidade, cancellationToken);

        await _unitOfWork.Commit(cancellationToken);

        return new BindSeriePeriodoUnidadeOutput();
    }
}
