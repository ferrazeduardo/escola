using MediatR;

namespace Rede.Application.UseCases.UnidadeUseCase.AddUnidade;

public class AddUnidadeInput : IRequest<AddUnidadePayload>
{
    public int id_rede { get; set; }
    public string numeroUnidade { get; set; }
    public string cep { get; set; }
    public string endereco { get; set; }
    public string complemento { get; set; }
    public int codigoUsuario { get; set; }
}