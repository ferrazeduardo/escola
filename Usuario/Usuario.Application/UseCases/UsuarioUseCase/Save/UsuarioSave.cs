using MediatR;
using Usuario.Application.UseCases.UsuarioUseCase.AddPerfilUsuarioRede;
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
    private IMediator _mediator;

    public UsuarioSave(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork,IMediator mediator)
    {
        _usuarioRepository = usuarioRepository;
        _unitOfWork = unitOfWork;
        _mediator = mediator;
    }

    public async Task<UsuarioSaveOutput> Handle(UsuarioSaveInput request, CancellationToken cancellationToken)
    {
        domain.Usuario usuario = new(request.nome, request.dataNascimento, request.cpf, request.email, request.senha, request.ehRaiz);
        usuario.SetSalt();
        usuario.SetSenhaCriptografada();

        await _usuarioRepository.Inserir(usuario, cancellationToken);

        await _unitOfWork.Commit(cancellationToken);

        if(usuario.ST_RAIZ) await _mediator.Send(new AddPerfilUsuarioRedeInput(request.redeId, 1, usuario.Id), cancellationToken);

        UsuarioSaveOutput usuarioSaveOutput = new();
        usuarioSaveOutput.codigo = usuario.Id;
        return usuarioSaveOutput;
    }

}