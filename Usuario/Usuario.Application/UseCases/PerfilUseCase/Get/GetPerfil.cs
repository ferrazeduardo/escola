using System;
using MediatR;
using Usuario.Domain.Exception;
using Usuario.Domain.Interface.Repository;

namespace Usuario.Application.UseCases.PerfilUseCase.Get;

public class GetPerfil : IRequestHandler<GetPerfilInput, GetPerfilOutput>
{
    private IPerfilRepository _perfilRepository;

    public GetPerfil(IPerfilRepository perfilRepository)
    {
        _perfilRepository = perfilRepository;
    }
    public async Task<GetPerfilOutput> Handle(GetPerfilInput request, CancellationToken cancellationToken)
    {
        var perfil = await _perfilRepository.Obter(x => x.Id == request.id, false);

        NotFoundException.IsNull(perfil, "Perfil não encontrado");

        GetPerfilOutput getPerfilOutput = new();
        getPerfilOutput.From(perfil);
        return getPerfilOutput;
    }
}
