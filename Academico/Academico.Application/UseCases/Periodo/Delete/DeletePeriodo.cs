using System;
using Academico.Domain.Exception;
using Academico.Domain.Interface.Repository;
using MediatR;

namespace Academico.Application.UseCases.Periodo.Delete;

public class DeletePeriodo : IRequestHandler<DeletePeriodoInput, DeletePeriodoOutput>
{
    private IPeriodoRepository _periodoRepository;

    public DeletePeriodo(IPeriodoRepository periodoRepository)
    {
        _periodoRepository = periodoRepository;
    }
    public async Task<DeletePeriodoOutput> Handle(DeletePeriodoInput request, CancellationToken cancellationToken)
    {
        var periodo = await _periodoRepository.Get(x => x.Id == request.id);

        NotFoundException.IsNull(periodo, "Período não encontrado");

        await _periodoRepository.Delete(periodo, cancellationToken);

        return new DeletePeriodoOutput();

    }
}
