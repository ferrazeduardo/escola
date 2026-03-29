using MediatR;

namespace Rede.Application.UseCases.RedeUseCase.Obter;

public class ObterRedeInput : IRequest<ObterRedeOutput>
{
    public int id { get; set; }
}