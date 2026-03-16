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
    private IUnitOfWork _unitOfWork;
    private IRedeClient _redeClient;
    private IRedeRepository _redeRepository;
    private IUsuarioRedeRepository _usuarioRedeRepository;

    public VincularRede(
        IUnitOfWork unitOfWork,
        IRedeClient redeClient,
        IRedeRepository redeRepository,
        IUsuarioRedeRepository usuarioRedeRepository
        )
    {
        _unitOfWork = unitOfWork;
        _redeClient = redeClient;
        _redeRepository = redeRepository;
        _usuarioRedeRepository = usuarioRedeRepository;
    }

    public async Task<VincularRedeOutput> Handle(VincularRedeInput request, CancellationToken cancellationToken)
    {
        Rede rede = await _redeClient.ObterRede(request.id_rede);

        NotFoundException.IsNull(rede, "Rede não existe");

        await _redeRepository.Inserir(rede, cancellationToken);

        UsuarioRede usuarioRede = new UsuarioRede
        {
            ID_USUARIO = request.id_usuario,
            ID_REDE = request.id_rede
        };

        await _usuarioRedeRepository.Inserir(usuarioRede, cancellationToken);

        await _unitOfWork.Commit(cancellationToken);

        return new VincularRedeOutput();
    }
}
