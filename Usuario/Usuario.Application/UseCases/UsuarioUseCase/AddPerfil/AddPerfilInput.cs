using System;
using MediatR;

namespace Usuario.Application.UseCases.UsuarioUseCase.AddPerfil;

public class AddPerfilInput : IRequest<AddPerfilOutput>
{
    public int id_usuario { get; set; }
    public int id_rede { get; set; }
    public int id_perfil { get; set; }
}
