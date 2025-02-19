namespace Rede.Application.UseCases.RedeUseCase.Obter;

public class ObterRedePayload
{

    public Guid Id { get; set; }
    public string razaoSocial { get; set; }
    public string cnpj { get; set; }
}