using MediatR;
using Pessoa.Application.UseCase.AlunoUseCase.Save;
using Pessoa.Domain.DataTransferObject;

namespace Pessoa.Api.Pessoa;

public class Mutation
{
    public async Task<SaveAlunoPayload> SavePessoaAsync(SaveAlunoInput saveAlunoInput, [Service] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var output = await mediator.Send(saveAlunoInput, cancellationToken);
        return output;
    }
}