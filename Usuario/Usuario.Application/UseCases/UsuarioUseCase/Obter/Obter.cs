using System;
using System.Linq.Expressions;
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

        IDictionary<bool, Expression<Func<AppDomain.Usuario, bool>>> dict = new Dictionary<bool, Expression<Func<AppDomain.Usuario, bool>>>
        {
            { request.id > 0, x => x.Id == request.id },
            { String.IsNullOrEmpty(request.cpf) is false,  x => x.NR_CPF == request.cpf }
        };

        var func = dict.FirstOrDefault(x => x.Key).Value ?? throw new Exception("Filtro inválido");

        AppDomain.Usuario usuario = await _usuarioRepository.Obter(func);

        return new ObterOutput
        {
            Id = usuario.Id,
            Nome = usuario.NM_USUARIO,
            Email = usuario.DS_EMAIL
        };
    }
}
