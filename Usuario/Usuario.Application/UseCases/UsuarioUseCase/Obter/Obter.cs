using System;
using MediatR;
using Usuario.Domain.Interface.Repository;
using AppDomain = Usuario.Domain.Entity;

namespace Usuario.Application.UseCases.UsuarioUseCase.Obter;

public class Obter : IRequestHandler<ObterInput, ObterOutput>
{
    private IUsuarioRepository _usuarioRepository;

    public Obter(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }


    public async Task<ObterOutput> Handle(ObterInput request, CancellationToken cancellationToken)
    {
        AppDomain.Usuario usuario = await _usuarioRepository.Obter(x => x.Id == request.id);

        return new ObterOutput
        {
            Id = usuario.Id,
            Nome = usuario.NM_USUARIO,
            Email = usuario.DS_EMAIL
        };
    }
}
