namespace Rede.Application.UseCases.DiaVencimentoUseCase.AddDiaVencimento;

public class AddDiaVEncimentoPayload
{

    public AddDiaVEncimentoPayload()
    {
        vencimentos = new();
    }
    public List<int> vencimentos { get; set; }
}