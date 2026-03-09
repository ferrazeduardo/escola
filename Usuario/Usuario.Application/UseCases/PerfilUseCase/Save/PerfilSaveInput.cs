using System;
using MediatR;

namespace Usuario.Application.UseCases.PerfilUseCase.Save;

public class PerfilSaveInput : IRequest<PerfilSaveOutput>
{
    public string descricao { get; set; }
}
