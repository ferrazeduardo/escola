using MediatR;

namespace Rede.Application.UseCases.DiaVencimentoUseCase.AddDiaVencimento;

public class AddDiaVencimentoInput : IRequest<AddDiaVEncimentoPayload>
{
    public List<int> diaVencimento { get; set; }
    public int id_rede { get; set; }
}