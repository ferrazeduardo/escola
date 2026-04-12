using System;
using MediatR;
using Usuario.Domain.Interface.Repository;

namespace Usuario.Application.UseCases.PerfilUseCase.List;

public class ListPerfil : IRequestHandler<ListPerfilInput, ListPerfilOutput>
{
    private IPerfilRepository _perfilRepository;

    public ListPerfil(IPerfilRepository perfilRepository)
    {
        _perfilRepository = perfilRepository;
    }

    public async Task<ListPerfilOutput> Handle(ListPerfilInput request, CancellationToken cancellationToken)
    {
        var perfis = await _perfilRepository.ObterTodos();

        ListPerfilOutput output = new();


        return output;
    }

    
}
