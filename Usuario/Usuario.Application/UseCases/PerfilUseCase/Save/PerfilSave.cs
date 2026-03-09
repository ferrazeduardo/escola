using System;
using MediatR;
using Usuario.Domain.Entity;
using Usuario.Domain.Interface;
using Usuario.Domain.Interface.Repository;

namespace Usuario.Application.UseCases.PerfilUseCase.Save;

public class PerfilSave : IRequestHandler<PerfilSaveInput, PerfilSaveOutput>
{
    private IPerfilRepository _perfilRepository;
    private IUnitOfWork _unitOfWork;

    public PerfilSave(IPerfilRepository perfilRepository, IUnitOfWork unitOfWork)
    {
        _perfilRepository = perfilRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<PerfilSaveOutput> Handle(PerfilSaveInput request, CancellationToken cancellationToken)
    {
        Perfil perfil = new(request.descricao);

        await _perfilRepository.Inserir(perfil, cancellationToken);

        await _unitOfWork.Commit(cancellationToken);

        PerfilSaveOutput perfilSaveOutput = new();
        perfilSaveOutput.id = perfil.Id;

        return perfilSaveOutput;
    }
}
