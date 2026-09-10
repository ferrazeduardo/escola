using MediatR;

namespace Rede.Application.UseCases.RedeUseCase.AddUnidade;

public class AddUnidadeInput : IRequest<AddUnidadePayload>
{
    public int id_rede { get; set; }
    public int id_unidade { get; set; }
   
}