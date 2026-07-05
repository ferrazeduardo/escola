using System;
using Academico.Domain.Exception;
using Academico.Domain.Interface.Repository;
using MediatR;

namespace Academico.Application.UseCases.Materia.UpdateStatus;

public class UpdateStatus : IRequestHandler<UpdateStatusInput, UpdateStatusOutput>
{
    private IMateriaRepository _materiaRepository;

    public UpdateStatus(IMateriaRepository materiaRepository)
    {
        _materiaRepository = materiaRepository;
    }
    public async Task<UpdateStatusOutput> Handle(UpdateStatusInput request, CancellationToken cancellationToken)
    {
        var materia = await _materiaRepository.Get(x => x.Id == request.id, false);
        NotFoundException.IsNull(materia, "Matéria não existe");

        materia.UpdateStatus(request.status);
        await _materiaRepository.Update(materia, cancellationToken);
        return new UpdateStatusOutput();
    }
}
