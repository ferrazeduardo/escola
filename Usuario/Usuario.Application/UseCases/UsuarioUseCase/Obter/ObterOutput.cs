using System;
using Usuario.Application.UseCases.UsuarioUseCase.Common;

namespace Usuario.Application.UseCases.UsuarioUseCase.Obter;

public class ObterOutput
{

    public UsuarioOutput usuario { get; set; }

    internal void From(Domain.Entity.Usuario usuarioD)
    {
        usuario.id = usuarioD.Id;
        usuario.nome = usuarioD.NM_USUARIO;
        usuario.email = usuarioD.DS_EMAIL;
        usuario.cpf = usuarioD.NR_CPF;
        usuario.dataNascimento = usuarioD.DT_NASCIMENTO;
    }
}
