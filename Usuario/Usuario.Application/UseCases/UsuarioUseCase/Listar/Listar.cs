using System;
using MediatR;
using Usuario.Domain.Interface.Repository;

namespace Usuario.Application.UseCases.UsuarioUseCase.Listar;

public class Listar : IRequestHandler<ListarInput, List<ListarOutput>>
{
    private IUsuarioRepository _usuarioRepository;

    public Listar(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<List<ListarOutput>> Handle(ListarInput request, CancellationToken cancellationToken)
    {
        var usuarios = await _usuarioRepository.Listar((i) => i.NM_USUARIO == request.nome);

        List<ListarOutput> listarOutputs = usuarios.Select(MapearParaListarOutput()).ToList();

        return listarOutputs;
    }

    private  Func<Domain.Entity.Usuario, ListarOutput> MapearParaListarOutput()
    {
        return u => new ListarOutput
        {
            id = u.Id,
            nome = u.NM_USUARIO,
            dataNascimento = u.DT_NASCIMENTO,
            cpf = u.NR_CPF
        };
    }
}
