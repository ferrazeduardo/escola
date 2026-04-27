using System;
using MediatR;
using Usuario.Domain.Exception;
using Usuario.Domain.Interface.Repository;
using Usuario.Domain.Interface.Service;

namespace Usuario.Application.UseCases.AuthenticationUseCase.Login;

public class Login : IRequestHandler<LoginInput, LoginOutput>
{
    private IUsuarioRepository _usuarioRepository;
    private ITokenService _tokenService;

    public Login(IUsuarioRepository usuarioRepository, ITokenService tokenService)
    {
        _usuarioRepository = usuarioRepository;
        _tokenService = tokenService;
    }

    public async Task<LoginOutput> Handle(LoginInput request, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.Obter(x => x.DS_EMAIL == request.login);
        NotFoundException.IsNull(usuario, "Usuario não existe com este login");
        usuario.VerificarSenha(request.senha);
        var output = new LoginOutput();
        output.token = _tokenService.GerarToken(usuario);
        return output;
    }
}
