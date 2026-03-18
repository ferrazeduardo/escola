using System;
using MediatR;
using Usuario.Domain.Entity;
using Usuario.Domain.Exception;
using Usuario.Domain.Interface;
using Usuario.Domain.Interface.HttpClients;
using Usuario.Domain.Interface.Repository;

namespace Usuario.Application.UseCases.UsuarioUseCase.VincularRede;

public class VincularRede : IRequestHandler<VincularRedeInput, VincularRedeOutput>
{
  private IUsuarioRepository _usuarioRepository;
    private IUnitOfWork _unitOfWork;
    private IRedeClient _redeClient;
    private IRedeRepository _redeRepository;

    public VincularRede(
        IUsuarioRepository usuarioRepository,
        IUnitOfWork unitOfWork,
        IRedeClient redeClient,
        IRedeRepository redeRepository)
    {
        _usuarioRepository = usuarioRepository;
        _unitOfWork = unitOfWork;
        _redeClient = redeClient;
        _redeRepository = redeRepository;
    }

    public async Task<VincularRedeOutput> Handle(VincularRedeInput request, CancellationToken cancellationToken)
    {
        Rede rede = await _redeClient.ObterRede(request.id_rede);

        NotFoundException.IsNull(rede, "Rede não existe");

        var usuario = await _usuarioRepository.Obter(x => x.Id == request.id_usuario,false);
        await _redeRepository.Inserir(rede, cancellationToken);
        usuario.AddRede(rede);

        await _unitOfWork.Commit(cancellationToken);

        return new VincularRedeOutput();
    }
}
