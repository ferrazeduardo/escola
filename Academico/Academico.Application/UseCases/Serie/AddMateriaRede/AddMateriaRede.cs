using System;
using Academico.Domain.Entity;
using Academico.Domain.Exception;
using Academico.Domain.Interface;
using Academico.Domain.Interface.Repository;
using MediatR;

namespace Academico.Application.UseCases.Serie.AddMateriaRede;

public class AddMateriaRede : IRequestHandler<AddMateriaRedeInput, AddMateriaRedeOutput>
{
    private IUnitOfWork _unitOfWork;
    private ISerieMateriaRedeRepository _serieMateriaRedeRepository;
    private ISerieRepository _serieRepository;

    public AddMateriaRede(IUnitOfWork unitOfWork, ISerieMateriaRedeRepository serieMateriaRedeRepository, ISerieRepository serieRepository)
    {
        _unitOfWork = unitOfWork;
        _serieMateriaRedeRepository = serieMateriaRedeRepository;
        _serieRepository = serieRepository;
    }

    public async Task<AddMateriaRedeOutput> Handle(AddMateriaRedeInput request, CancellationToken cancellationToken)
    {
        var serie = await _serieRepository.Get(x => x.Id == request.serieId && x.redeId == request.redeId);
        NotFoundException.IsNull(serie, "Serie não existe");
        serie.VerificaSeMateriaJaExiste(request.materiaId);

        request.materiaId.ForEach(async id =>
        {
            SerieMateriaRede serieMateriaRede = new(request.serieId, request.redeId, id);
            await _serieMateriaRedeRepository.Cadastrar(serieMateriaRede, cancellationToken);
        });
        
        await _unitOfWork.Commit(cancellationToken);

        return new AddMateriaRedeOutput();
    }
}
