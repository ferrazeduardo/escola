using System;
using MediatR;
using Usuario.Domain.Exception;
using Usuario.Domain.Interface;
using Usuario.Domain.Interface.HttpClients;
using Usuario.Domain.Interface.Repository;

namespace Usuario.Application.UseCases.UsuarioUseCase.AddPerfilUsuarioRede;

public class AddPerfilUsuarioRede : IRequestHandler<AddPerfilUsuarioRedeInput, AddPerfilUsuarioRedeOutput>
{
    private IUnitOfWork _unitOfWork;
    private IPerilUsuarioRedeRepository _perfilUsuarioRedeRespository;
    private IUsuarioRepository _usuarioRepository;
    private IRedeClient _redeClient;
    private IPerfilRepository _perfilRepository;

    public AddPerfilUsuarioRede(
        IPerilUsuarioRedeRepository perfilUsuarioRedeRespository,
        IUnitOfWork unitOfWork,
        IUsuarioRepository usuarioRepository,
        IRedeClient redeClient,
        IPerfilRepository perfilRepository)
    {
        _unitOfWork = unitOfWork;
        _perfilUsuarioRedeRespository = perfilUsuarioRedeRespository;
        _usuarioRepository = usuarioRepository;
        _redeClient = redeClient;
        _perfilRepository = perfilRepository;
    }
    public async Task<AddPerfilUsuarioRedeOutput> Handle(AddPerfilUsuarioRedeInput request, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.Obter(x => x.Id == request.usuarioId);
        NotFoundException.IsNull(usuario, "Usuario não encontrado");

        var rede = await _redeClient.ObterRede(request.redeId);
        NotFoundException.IsNull(rede, "Rede não encontrada");

        var perfil = await _perfilRepository.Obter(x => x.Id == request.perfilId);
        NotFoundException.IsNull(perfil, "Perfil não encontrado");


        usuario.AddPerfilUsuarioRede(rede.Id, perfil.Id);
        await _perfilUsuarioRedeRespository.Inserir(usuario.perfilUsuarioRedes.First(), cancellationToken);

        return new AddPerfilUsuarioRedeOutput();
    }
}
