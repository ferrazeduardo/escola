using System;
using MediatR;

namespace Usuario.Application.UseCases.PerfilUseCase.Create;

public class CreatePerfilInput : IRequest<CreatePerfilOutput>
{
    public string descricao { get; set; }
}
