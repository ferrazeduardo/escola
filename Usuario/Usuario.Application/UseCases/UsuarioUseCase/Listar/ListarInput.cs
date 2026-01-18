using System;
using MediatR;

namespace Usuario.Application.UseCases.UsuarioUseCase.Listar;

public class ListarInput : IRequest<List<ListarOutput>>
{
    public string nome { get; set; }
}
