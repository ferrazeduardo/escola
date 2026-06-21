using System;
using Academico.Domain.Exception;
using Academico.Domain.Interface;
using Academico.Domain.Interface.Repository;
using MediatR;

namespace Academico.Application.UseCases.Periodo.Update;

public class UpdatePeriodo : IRequestHandler<UpdatePeriodoInput, UpdatePeriodoOutput>
{
    private IUnitOfWork _unitOfWork;
    private IPeriodoRepository _periodoRepository;

    public UpdatePeriodo(IPeriodoRepository periodoRepository,IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _periodoRepository = periodoRepository;
    }
    public async Task<UpdatePeriodoOutput> Handle(UpdatePeriodoInput request, CancellationToken cancellationToken)
    {
       var periodo = await _periodoRepository.Get(x => x.Id == request.id);
       NotFoundException.IsNull(periodo, "Periodo não encontrado");

       periodo.Update(request.status, request.dateFim,request.dateInicio);

       await _unitOfWork.Commit(cancellationToken);

       return new UpdatePeriodoOutput();
    }
}
