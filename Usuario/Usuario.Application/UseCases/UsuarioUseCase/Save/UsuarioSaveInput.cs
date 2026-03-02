using MediatR;

namespace Usuario.Application.UseCases.UsuarioUseCase.Save;

public record UsuarioSaveInput(string nome, string cpf, DateTime dataNascimento,string email,string senha,string login,int id_rede) : IRequest<UsuarioSaveOutput>
{
}
