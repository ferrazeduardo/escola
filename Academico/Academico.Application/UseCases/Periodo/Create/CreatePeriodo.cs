using System;
using Academico.Domain.Interface.Repository;
using domain = Academico.Domain.Entity;
using MediatR;
using Academico.Domain.Exception;
using Academico.Domain.Interface;

namespace Academico.Application.UseCases.Periodo.Create;

public class CreatePeriodo : IRequestHandler<CreatePeriodoInput, CreatePeriodoOutput>
{
    private IPeriodoRepository _periodoRepository;
    private IUnitOfWork _unitOfWork;

    public CreatePeriodo(IPeriodoRepository periodoRepository,IUnitOfWork unitOfWork)
    {
        _periodoRepository = periodoRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<CreatePeriodoOutput> Handle(CreatePeriodoInput request, CancellationToken cancellationToken)
    {
        domain.Periodo periodo = new(request.ano,request.dataInicio, request.dataFim);

        var periodoJaExiste = await _periodoRepository.Get(x => x.NR_ANO == request.ano);
        AlreadyExistsException.IsNotNull("Periodo", periodoJaExiste, request.ano);

        await _periodoRepository.Cadastrar(periodo, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

        return new CreatePeriodoOutput()
        {
            id = periodo.Id  
        };


    }
}
