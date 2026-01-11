using System;
using MediatR;

namespace Usuario.Application.UseCases.UsuarioUseCase.Obter;

public class ObterInput : IRequest<ObterOutput>
{
    public string? cpf {get;set;}

    public int id { get; set; }
}
