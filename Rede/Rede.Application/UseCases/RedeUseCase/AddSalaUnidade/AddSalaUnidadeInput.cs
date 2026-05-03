using System;
using MediatR;

namespace Rede.Application.UseCases.RedeUseCase.AddSalaUnidade;

public class AddSalaUnidadeInput : IRequest<AddSalaUnidadeOutput>
{
    public int redeId { get; set; }
    public int unidadeId { get; set; }
    public string numeroSala { get; set; }
    public int quantidade { get; set; }
}
