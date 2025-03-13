using MediatR;
using Pessoa.Application.Interface.Repository;
using Pessoa.Domain.DataTransferObject;

namespace Pessoa.Application.UseCase.AlunoUseCase.Save;

public class SaveAlunoInput : IRequest<SaveAlunoPayload>
{
    public Guid id_rede { get; set; }
    public PessoaDto aluno { get; set; }
    public PessoaDto pai { get; set; }
    public PessoaDto mae { get; set; }
}

