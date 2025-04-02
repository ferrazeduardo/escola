using Pessoa.Domain.Entity;
using Pessoa.Domain.SeedWorks;

namespace Pessoa.Application.Interface.Repository;

public interface IPessoaRepository : IRepository<Domain.SeedWorks.Pessoa>
{
    Task<Domain.SeedWorks.Pessoa> ObterPeloCpf(string cpf, Guid id_rede);
}