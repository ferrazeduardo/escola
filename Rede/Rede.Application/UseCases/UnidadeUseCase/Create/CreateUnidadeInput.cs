using System;
using MediatR;

namespace Rede.Application.UseCases.UnidadeUseCase.Create;

public class CreateUnidadeInput : IRequest<CreateUnidadeOutput>
{
    public string numeroUnidade { get; set; }
    public string cep { get; set; }
    public string endereco { get; set; }
    public string complemento { get; set; }
    public int usuarioRegistro { get; set; }
    public List<string> telefones { get; set; }
}
