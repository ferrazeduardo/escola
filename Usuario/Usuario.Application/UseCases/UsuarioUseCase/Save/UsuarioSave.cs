using MediatR;
using Usuario.Application.UseCases.UsuarioUseCase.Save;
using Usuario.Domain.Entity;
using Usuario.Domain.Interface;
using Usuario.Domain.Interface.HttpClients;
using Usuario.Domain.Interface.Repository;
using domain = Usuario.Domain.Entity;

namespace Usuario.Application.UseCases.Save;

public class UsuarioSave : IRequestHandler<UsuarioSaveInput, UsuarioSaveOutput>
{
    private IUsuarioRepository _usuarioRepository;
    private IUnitOfWork _unitOfWork;
    private IRedeClient _redeClient;

    public UsuarioSave(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork, IRedeClient redeClient)
    {
        _usuarioRepository = usuarioRepository;
        _unitOfWork = unitOfWork;
        _redeClient = redeClient;
    }

    public async Task<UsuarioSaveOutput> Handle(UsuarioSaveInput request, CancellationToken cancellationToken)
    {
        domain.Usuario usuario = new(request.nome, request.dataNascimento, request.cpf, request.email, request.senha);
        usuario.SetSalt();
        usuario.HashSenha();

        Rede rede = await _redeClient.ObterRede(request.id_rede);
        usuario.AddRede(rede);
        
        await _usuarioRepository.Inserir(usuario, cancellationToken);

        await _unitOfWork.Commit(cancellationToken);
        UsuarioSaveOutput usuarioSaveOutput = new();
        usuarioSaveOutput.codigo = usuario.Id;
        return usuarioSaveOutput;
    }

}