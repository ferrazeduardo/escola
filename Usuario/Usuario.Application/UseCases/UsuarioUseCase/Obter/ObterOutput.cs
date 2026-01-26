using System;

namespace Usuario.Application.UseCases.UsuarioUseCase.Obter;

public class ObterOutput
{

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string cpf { get; set; }
    public DateTime dataNascimento { get; set; }

}
