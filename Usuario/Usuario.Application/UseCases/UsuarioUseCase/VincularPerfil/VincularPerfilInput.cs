using System;
using MediatR;

namespace Usuario.Application.UseCases.UsuarioUseCase.VincularPerfil;

public class VincularPerfilInput : IRequest<VincularPerfilOutput>
{
    public int id_usuario { get; set; }
    public int id_rede { get; set; }
    public int id_perfil { get; set; }
}
