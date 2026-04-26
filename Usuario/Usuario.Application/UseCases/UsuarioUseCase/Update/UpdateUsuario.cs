using System;
using MediatR;
using Usuario.Domain.Exception;
using Usuario.Domain.Interface;
using Usuario.Domain.Interface.Repository;

namespace Usuario.Application.UseCases.UsuarioUseCase.Update;

public class UpdateUsuario : IRequestHandler<UpdateUsuarioInput, UpdateUsuarioOutput>
{
    private IUsuarioRepository _usuarioRepository;
    private IUnitOfWork _unitOfWork;

    public UpdateUsuario(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
    {
        _usuarioRepository = usuarioRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateUsuarioOutput> Handle(UpdateUsuarioInput request, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.Obter(x => x.Id == request.usuarioId);
        NotFoundException.IsNull(usuario, "Usuário não encontrado");

        usuario.Update(request.nome, request.cpf);
        await _unitOfWork.Commit(cancellationToken);

        return new UpdateUsuarioOutput();
    }
}
