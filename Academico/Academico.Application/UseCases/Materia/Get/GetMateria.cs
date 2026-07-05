using System;
using Academico.Domain.Exception;
using Academico.Domain.Interface.Repository;
using MediatR;

namespace Academico.Application.UseCases.Materia.Get;

public class GetMateria : IRequestHandler<GetMateriaInput, GetMateriaOutput>
{
    private IMateriaRepository _materiaRepository;

    public GetMateria(IMateriaRepository materiaRepository)
    {
        _materiaRepository = materiaRepository;
    }
    public async Task<GetMateriaOutput> Handle(GetMateriaInput request, CancellationToken cancellationToken)
    {
        var materia = await _materiaRepository.Get(x => x.Id == request.id, false);
        NotFoundException.IsNull(materia, "Matéria não Existe");

        return new GetMateriaOutput().From(materia);
    }
}
