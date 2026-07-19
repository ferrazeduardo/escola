using System;
using Academico.Domain.Interface;
using Academico.Domain.Interface.Repository;
using domain = Academico.Domain.Entity;
using MediatR;
using Academico.Domain.Exception;

namespace Academico.Application.UseCases.Serie.Create;

public class CreateSerie : IRequestHandler<CreateSerieInput, CreateSerieOutput>
{
    private ISerieRepository _serieRepository;
    private IUnitOfWork _unitOfWork;

    public CreateSerie(ISerieRepository serieRepository, IUnitOfWork unitOfWork)
    {
        _serieRepository = serieRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<CreateSerieOutput> Handle(CreateSerieInput request, CancellationToken cancellationToken)
    {
        var serieJaExiste = await _serieRepository.Get(x => x.NR_SERIE == request.numero);
        AlreadyExistsException.IsNotNull(nameof(domain.Serie), serieJaExiste, request.numero.ToString());

        var serie = new domain.Serie(request.numero);

        await _serieRepository.Cadastrar(serie, cancellationToken);

        return new CreateSerieOutput(serie.Id);
    }
}
