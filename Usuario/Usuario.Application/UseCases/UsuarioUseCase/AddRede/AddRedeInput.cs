using System;
using MediatR;

namespace Usuario.Application.UseCases.UsuarioUseCase.AddRede;

public class AddRedeInput : IRequest<AddRedeOutput>
{
    public int id_usuario { get; set; }
    public int id_rede { get; set; }
}
