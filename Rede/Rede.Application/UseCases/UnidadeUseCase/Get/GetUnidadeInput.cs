using System;
using MediatR;

namespace Rede.Application.UseCases.UnidadeUseCase.Get;

public class GetUnidadeInput : IRequest<GetUnidadeOutput>
{
    public int id { get; set; }
}
