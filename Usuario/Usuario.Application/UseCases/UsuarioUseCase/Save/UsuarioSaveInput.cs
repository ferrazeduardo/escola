using MediatR;

namespace Usuario.Application.UseCases.UsuarioUseCase.Save;

public record UsuarioSaveInput(string nome, string cpf,DateTime dataNascimento) : IRequest<UsuarioSaveOutput>
{

}
