using System;
using MediatR;
using Usuario.Domain.Interface.Repository;

namespace Usuario.Application.UseCases.PerfilUseCase.Listar;

public class ListarPerfil : IRequestHandler<ListarPerfilInput, ListarPerfilOutput>
{
    private IPerfilRepository _perfilRepository;

    public ListarPerfil(IPerfilRepository perfilRepository)
    {
        _perfilRepository = perfilRepository;
    }

    public async Task<ListarPerfilOutput> Handle(ListarPerfilInput request, CancellationToken cancellationToken)
    {
        var perfis = await _perfilRepository.ObterTodos();

        ListarPerfilOutput output = new();


        return output;
    }

    
}
