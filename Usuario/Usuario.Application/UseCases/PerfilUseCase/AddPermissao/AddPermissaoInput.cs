using System;
using MediatR;

namespace Usuario.Application.UseCases.PerfilUseCase.AddPermissao;

public class AddPermissaoInput : IRequest<AddPermissaoOutput>
{
    public int permissaoId { get; set; }
    public int perfilId { get; set; }
}
