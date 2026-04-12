using System;
using MediatR;

namespace Usuario.Application.UseCases.PerfilUseCase.Update;

public class UpdatePerfilInput : IRequest<UpdatePerfilOutput>
{
    public int id { get; set; }
    public string descricao { get; set; }
}
