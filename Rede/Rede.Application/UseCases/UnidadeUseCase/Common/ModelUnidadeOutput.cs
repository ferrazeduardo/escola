using System;

namespace Rede.Application.UseCases.UnidadeUseCase.Common;

public class ModelUnidadeOutput
{
    public int id { get; set; }
    public string endereco { get; set; }
    public string numero { get; set; }
    public string complemento { get; set; }
    public string cep { get; set; }
    public bool status { get; set; }
}
