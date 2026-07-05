using System;
using Academico.Domain.Interface;
using Academico.Domain.Interface.Repository;
using MediatR;
using domain = Academico.Domain.Entity;

namespace Academico.Application.UseCases.Materia.Create;

public class CreateMateria : IRequestHandler<CreateMateriaInput, CreateMateriaOutput>
{
    private IMateriaRepository _materiaRepository;
    private IUnitOfWork _unitOfWork;

    public CreateMateria(IMateriaRepository materiaRepository, IUnitOfWork unitOfWork)
    {
        _materiaRepository = materiaRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<CreateMateriaOutput> Handle(CreateMateriaInput request, CancellationToken cancellationToken)
    {
        var materia = new domain.Materia(request.descricao);

        await _materiaRepository.Create(materia, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

        return new CreateMateriaOutput()
        {
            id = materia.Id
        };
    }
}
