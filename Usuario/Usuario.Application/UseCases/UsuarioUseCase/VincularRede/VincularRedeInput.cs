using System;
using MediatR;

namespace Usuario.Application.UseCases.UsuarioUseCase.VincularRede;

public class VincularRedeInput : IRequest<VincularRedeOutput>
{
    public int id_usuario { get; set; }
    public int id_rede { get; set; }
}
