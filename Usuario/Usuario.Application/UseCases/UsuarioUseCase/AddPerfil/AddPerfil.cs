using System;
using MediatR;
using Usuario.Domain.Entity;
using Usuario.Domain.Interface;
using Usuario.Domain.Interface.Repository;

namespace Usuario.Application.UseCases.UsuarioUseCase.AddPerfil;

public class AddPerfil : IRequestHandler<AddPerfilInput, AddPerfilOutput>
{
    private IUsuarioRepository _usuarioRepository;
    private IUnitOfWork _unitOfWork;
    private IPerfilRepository _perfilRepository;

    public AddPerfil(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork,IPerfilRepository perfilRepository)
    {
        _usuarioRepository = usuarioRepository;
        _unitOfWork = unitOfWork;
        _perfilRepository = perfilRepository;
    }

    public async Task<AddPerfilOutput> Handle(AddPerfilInput request, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.Obter((x) => x.Id == request.id_usuario);

        var perfil = await _perfilRepository.Obter((x) => x.Id == request.id_perfil);

        usuario.addPerfil(perfil,request.id_perfil);

        await _unitOfWork.Commit(cancellationToken);

        return new AddPerfilOutput();
    }
}
