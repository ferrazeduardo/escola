using System;
using MediatR;
using Usuario.Domain.Interface.Repository;

namespace Usuario.Application.UseCases.PerfilUseCase.Listar;

public class ListarPerfil : IRequestHandler<ListarPerfilInput, List<ListarPerfilOutput>>
{
    private IPerfilRepository _perfilRepository;

    public ListarPerfil(IPerfilRepository perfilRepository)
    {
        _perfilRepository = perfilRepository;
    }

    public async Task<List<ListarPerfilOutput>> Handle(ListarPerfilInput request, CancellationToken cancellationToken)
    {
        var perfis = await _perfilRepository.ObterTodos();

        List<ListarPerfilOutput> output =  perfis.Select(MapearParaListarPerfilOutput()).ToList();

        return output;
    }

    public Func<Domain.Entity.Perfil, ListarPerfilOutput> MapearParaListarPerfilOutput()
    {
        return p => new ListarPerfilOutput
        {
            id = p.Id,
            descricao = p.DS_PERFIL
        };
    }
}
