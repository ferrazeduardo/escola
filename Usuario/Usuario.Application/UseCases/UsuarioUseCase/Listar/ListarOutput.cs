using System;

namespace Usuario.Application.UseCases.UsuarioUseCase.Listar;

public class ListarOutput
{
    public int id { get; set; }
    public string nome { get; set; }
    public string cpf { get; set; }
    public DateTime dataNascimento { get; set; }
}
