using System;
using MediatR;

namespace Usuario.Application.UseCases.UsuarioUseCase.AddPerfilUsuarioRede;

public record AddPerfilUsuarioRedeInput(int redeId, int perfilId, int usuarioId) : IRequest<AddPerfilUsuarioRedeOutput>;
