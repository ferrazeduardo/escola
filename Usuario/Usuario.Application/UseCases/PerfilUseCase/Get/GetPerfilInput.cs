using System;
using MediatR;

namespace Usuario.Application.UseCases.PerfilUseCase.Get;

public class GetPerfilInput : IRequest<GetPerfilOutput>
{
    public int id { get; set; }
}
