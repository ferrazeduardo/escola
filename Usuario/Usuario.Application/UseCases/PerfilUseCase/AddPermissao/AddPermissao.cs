using System;
using MediatR;
using Usuario.Domain.Exception;
using Usuario.Domain.Interface;
using Usuario.Domain.Interface.Repository;

namespace Usuario.Application.UseCases.PerfilUseCase.AddPermissao;

public class AddPermissao : IRequestHandler<AddPermissaoInput, AddPermissaoOutput>
{
    private IUnitOfWork _unitOfWork;
    private IPerfilRepository _perfilRepository;
    private IPermissaoRepository _permissaoRepository;
    private IPerfilPermissaoRepository _perfilPermissaoRepository;

    public AddPermissao(IPerfilPermissaoRepository perfilPermissaoRepository, IPerfilRepository perfilRepository, IPermissaoRepository permissaoRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork  = unitOfWork;
        _perfilRepository =  perfilRepository;
        _permissaoRepository = permissaoRepository;
        _perfilPermissaoRepository = perfilPermissaoRepository;
    }

    public async Task<AddPermissaoOutput> Handle(AddPermissaoInput request, CancellationToken cancellationToken)
    {
        var perfilAsync = _perfilRepository.Obter(x => x.Id == request.perfilId);
        var permissaoAsync = _permissaoRepository.Obter(x => x.Id == request.permissaoId);
        await Task.WhenAll(perfilAsync, permissaoAsync);
        var perfil =  await perfilAsync;
        var permissao = await permissaoAsync;

        NotFoundException.IsNull(perfil, "Perfil não encontrado");
        NotFoundException.IsNull(permissao, "Permissão não encontrada");

        await _perfilPermissaoRepository.Inserir(new Domain.Entity.PerfilPermissao(perfil.Id, permissao.Id), cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

        return new AddPermissaoOutput();
        
    }
}
