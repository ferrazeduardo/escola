using Pessoa.Domain.Entity;
using Pessoa.Domain.SeedWorks;

namespace Pessoa.Application.Interface.Repository;

public interface IPessoaRepository : IRepository<Domain.SeedWorks.Pessoa>
{
    Task InserirAluno(Aluno aluno,CancellationToken cancellationToken);
}