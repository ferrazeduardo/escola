using MediatR;
using Usuario.Application.UseCases.UsuarioUseCase.Save;

namespace Usuario.Application.UseCases.Save;

public class UsuarioSave : IRequestHandler<UsuarioSaveInput, UsuarioSaveOutput>
{
    public Task<UsuarioSaveOutput> Handle(UsuarioSaveInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}