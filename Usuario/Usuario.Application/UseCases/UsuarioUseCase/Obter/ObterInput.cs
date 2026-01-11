using System;
using MediatR;

namespace Usuario.Application.UseCases.UsuarioUseCase.Obter;

public class ObterInput : IRequest<ObterOutput>
{
    public int id { get; set; }
}
