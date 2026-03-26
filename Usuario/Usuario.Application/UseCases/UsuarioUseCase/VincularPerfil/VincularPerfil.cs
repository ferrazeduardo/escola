using System;
using MediatR;
using Usuario.Domain.Entity;
using Usuario.Domain.Interface;
using Usuario.Domain.Interface.Repository;

namespace Usuario.Application.UseCases.UsuarioUseCase.VincularPerfil;

public class VincularPerfil : IRequestHandler<VincularPerfilInput, VincularPerfilOutput>
{
    private IUsuarioRepository _usuarioRepository;
    private IUnitOfWork _unitOfWork;
    private IPerfilRepository _perfilRepository;

    public VincularPerfil(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork,IPerfilRepository perfilRepository)
    {
        _usuarioRepository = usuarioRepository;
        _unitOfWork = unitOfWork;
        _perfilRepository = perfilRepository;
    }

    public async Task<VincularPerfilOutput> Handle(VincularPerfilInput request, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.Obter((x) => x.Id == request.id_usuario);

        var perfil = await _perfilRepository.Obter((x) => x.Id == request.id_perfil);

        usuario.addPerfil(perfil,request.id_perfil);

        await _unitOfWork.Commit(cancellationToken);

        return new VincularPerfilOutput();
    }
}
