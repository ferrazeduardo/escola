using System;
using MediatR;

namespace Rede.Application.UseCases.UnidadeUseCase.Update;

public class UpdateUnidadeInput : IRequest<UpdateUnidadeOutput>
{
    public int id { get; set; }
    public string endereco { get; set; }
    public string cep { get; set; }
    public string numero { get; set; }
    public bool status { get; set; }
    public string complemento { get;  set; }
}
