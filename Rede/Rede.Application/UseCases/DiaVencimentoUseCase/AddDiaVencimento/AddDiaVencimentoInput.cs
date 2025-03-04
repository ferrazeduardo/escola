using MediatR;

namespace Rede.Application.UseCases.DiaVencimentoUseCase.AddDiaVencimento;

public class AddDiaVencimentoInput : IRequest<AddDiaVEncimentoPayload>
{
    public List<int> diaVencimento { get; set; }
    public Guid id_rede { get; set; }
}