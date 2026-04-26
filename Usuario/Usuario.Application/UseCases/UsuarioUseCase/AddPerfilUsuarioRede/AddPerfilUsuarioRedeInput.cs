using System;
using MediatR;

namespace Usuario.Application.UseCases.UsuarioUseCase.AddPerfilUsuarioRede;

public class AddPerfilUsuarioRedeInput : IRequest<AddPerfilUsuarioRedeOutput>
{
    public int redeId { get; set; }
    public int perfilId { get; set; }
    public int usuarioId { get; set; }
}
