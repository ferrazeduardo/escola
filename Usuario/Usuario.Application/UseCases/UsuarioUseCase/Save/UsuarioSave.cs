using MediatR;
using Usuario.Application.UseCases.UsuarioUseCase.Save;
using Usuario.Domain.Interface;
using Usuario.Domain.Interface.Repository;
using domain = Usuario.Domain.Entity;

namespace Usuario.Application.UseCases.Save;

public class UsuarioSave : IRequestHandler<UsuarioSaveInput, UsuarioSaveOutput>
{
    private IUsuarioRepository _usuarioRepository;
    private IUnitOfWork _unitOfWork;

    public UsuarioSave(IUsuarioRepository usuarioRepository,IUnitOfWork unitOfWork)
    {
        _usuarioRepository = usuarioRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UsuarioSaveOutput> Handle(UsuarioSaveInput request, CancellationToken cancellationToken)
    {
        domain.Usuario usuario = new(request.nome, request.dataNascimento, request.cpf, request.email, request.senha);
        usuario.SetSalt();
        usuario.HashSenha();
        await _usuarioRepository.Inserir(usuario, cancellationToken);

        await _unitOfWork.Commit(cancellationToken);
        UsuarioSaveOutput usuarioSaveOutput = new();
        usuarioSaveOutput.codigo = usuario.Id;
        return usuarioSaveOutput;
    }
    
}