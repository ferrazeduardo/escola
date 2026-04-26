using System;
using MediatR;

namespace Usuario.Application.UseCases.UsuarioUseCase.Update;

public class UpdateUsuarioInput : IRequest<UpdateUsuarioOutput>
{
    public int usuarioId { get; set; }
    public string nome { get; set; }
    public string cpf { get; set; }
}
