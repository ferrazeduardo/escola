using System;
using MediatR;
using Usuario.Domain.Interface;
using Usuario.Domain.Interface.Repository;

namespace Usuario.Application.UseCases.PerfilUseCase.Update;

public class UpdatePerfil : IRequestHandler<UpdatePerfilInput, UpdatePerfilOutput>
{
    private IPerfilRepository _perfilRepository;
    private IUnitOfWork _unitOfWork;

    public UpdatePerfil(IPerfilRepository perfilRepository,IUnitOfWork unitOfWork)
    {
        _perfilRepository = perfilRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<UpdatePerfilOutput> Handle(UpdatePerfilInput request, CancellationToken cancellationToken)
    {
        var perfil = await _perfilRepository.Obter(x => x.Id == request.id);

        if (perfil == null)
            throw new Exception("Perfil não encontrado");

        perfil.Update(request.descricao);   

        await _unitOfWork.Commit(cancellationToken);

        return new UpdatePerfilOutput();
    }
}
