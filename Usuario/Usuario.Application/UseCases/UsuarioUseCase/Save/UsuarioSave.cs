using MediatR;
using Usuario.Application.UseCases.UsuarioUseCase.Save;
using Usuario.Domain.Interface.Repository;
using domain = Usuario.Domain.Entity;

namespace Usuario.Application.UseCases.Save;

public class UsuarioSave : IRequestHandler<UsuarioSaveInput, UsuarioSaveOutput>
{
    private IUsuarioRepository _usuarioRepository;

    public UsuarioSave(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<UsuarioSaveOutput> Handle(UsuarioSaveInput request, CancellationToken cancellationToken)
    {
        domain.Usuario usuario = new(request.nome, request.dataNascimento, request.cpf, request.email, request.senha);
        usuario.SetSalt();
        usuario.HashSenha();
        int codigo = await _usuarioRepository.Inserir(usuario, cancellationToken);

        UsuarioSaveOutput usuarioSaveOutput = new();
        usuarioSaveOutput.codigo = codigo;
        return usuarioSaveOutput;
    }
    
}