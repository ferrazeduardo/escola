using System;
using MediatR;

namespace Rede.Application.UseCases.UnidadeUseCase.List;

public class ListUnidadeInput : IRequest<ListUnidadeOutput>
{
    public int id_rede { get; set; }
}
