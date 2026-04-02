using System;

namespace Usuario.Application.UseCases.UsuarioUseCase.Common;

public class UsuarioOutput
{
    public int id { get; set; }
    public string nome { get; set; }
    public string cpf { get; set; }
    public DateTime dataNascimento { get; set; }
    public string email { get; internal set; }
}
