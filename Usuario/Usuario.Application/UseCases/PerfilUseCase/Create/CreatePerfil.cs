using System;
using MediatR;
using Usuario.Domain.Entity;
using Usuario.Domain.Interface;
using Usuario.Domain.Interface.Repository;

namespace Usuario.Application.UseCases.PerfilUseCase.Create;

public class CreatePerfil : IRequestHandler<CreatePerfilInput, CreatePerfilOutput>
{
    private IPerfilRepository _perfilRepository;
    private IUnitOfWork _unitOfWork;

    public CreatePerfil(IPerfilRepository perfilRepository, IUnitOfWork unitOfWork)
    {
        _perfilRepository = perfilRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreatePerfilOutput> Handle(CreatePerfilInput request, CancellationToken cancellationToken)
    {
        Perfil perfil = new(request.descricao);

        await _perfilRepository.Inserir(perfil, cancellationToken);

        await _unitOfWork.Commit(cancellationToken);

        CreatePerfilOutput perfilSaveOutput = new();
        perfilSaveOutput.id = perfil.Id;

        return perfilSaveOutput;
    }
}
