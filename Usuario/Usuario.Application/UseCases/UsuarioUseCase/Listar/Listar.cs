using System;
using MediatR;
using Usuario.Application.UseCases.UsuarioUseCase.Common;
using Usuario.Domain.Interface.Repository;
using Usuario.Domain.Interface.SearchRepository;

namespace Usuario.Application.UseCases.UsuarioUseCase.Listar;

public class Listar : IRequestHandler<ListarInput, ListarOutput>
{
    private IUsuarioRepository _usuarioRepository;

    public Listar(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<ListarOutput> Handle(ListarInput request, CancellationToken cancellationToken)
    {

        var usuarios = await _usuarioRepository.Search(new SearchInput(request.pagina,request.quantidade,request.pesquisa,request.ordernadacao,request.order),cancellationToken);

        ListarOutput listarOutputs = new(
            usuarios.paginaAtual,
            usuarios.Quantidade,
            usuarios.Total,
            usuarios.Itens.Select(MapearParaListarOutput()).ToList()
        );

        return listarOutputs;
    }

    private  Func<Domain.Entity.Usuario, UsuarioOutput> MapearParaListarOutput()
    {
        return u => new UsuarioOutput
        {
            id = u.Id,
            nome = u.NM_USUARIO,
            dataNascimento = u.DT_NASCIMENTO,
            cpf = u.NR_CPF
        };
    }
}
